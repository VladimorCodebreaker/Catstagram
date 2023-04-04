using System;
using Catstagram.Data.Static;
using Catstagram.Models;
using Microsoft.AspNetCore.Identity;

namespace Catstagram.Data
{
    public class DatabaseInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                context.Database.EnsureCreated();

                // Posts
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(new List<Post>()
                    {
                        new Post()
                        {
                            Image = "/images/0.png",
                            Name = "NeonRX",
                            Email = "email@gmail.com",
                            Comment = "Feline good today 😻 #catsofinstagram #cutecats #meowstagram #catlove #kittygram"
                        },
                        new Post()
                        {
                            Image = "/images/1.png",
                            Name = "auroramusic",
                            Email = "email@gmail.com",
                            Comment = "Caturday snuggles are the best 🐾❤️ #caturday #catcuddles #catnap #weekendvibes"
                        },
                        new Post()
                        {
                            Image = "/images/2.png",
                            Name = "natari_illust",
                            Email = "email@gmail.com",
                            Comment = "Can you spot the kitty in this cozy scene? 🧐🐱 #wheresthecat #catcamouflage #cozyhome"
                        },
                        new Post()
                        {
                            Image = "/images/3.png",
                            Name = "fusegodesu",
                            Email = "email@gmail.com",
                            Comment = "Here's my adorable fur baby, isn't he cute? 😍🐾 #catmomlife #catlovers #furball #adorablecats"
                        },
                        new Post()
                        {
                            Image = "/images/4.png",
                            Name = "sakura_eu",
                            Email = "email@gmail.com",
                            Comment = "Just a little catnap to recharge 😴🐾 #catnaptime #relaxation #sleepycat #cozycat #catsofinsta"
                        },
                        new Post()
                        {
                            Image = "/images/5.png",
                            Name = "I_plum_I",
                            Email = "email@gmail.com",
                            Comment = "Caught this little guy mid-yawn 😹 #funnycats #catphotography #catsofig #yawningcat"
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string adminUserEmail = "admin@gmail.com"; // Change to an email chosen by you!

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com"; // Change to an email chosen by you!

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

