using System.Collections.Generic;
using Catstagram.Data;
using Catstagram.Data.IServices;
using Catstagram.Data.Services;
using Catstagram.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Configuration String
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Authentication and authorization
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Post/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Post}/{action=Index}/{id?}");

// Initialize Database
DatabaseInitializer.Seed(app);
DatabaseInitializer.SeedUsersAndRolesAsync(app).Wait();
app.Run();
