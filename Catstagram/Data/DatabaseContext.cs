using System;
using Catstagram.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Data
{
	public class DatabaseContext : IdentityDbContext<User>
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

        public DbSet<Post> Posts { get; set; }
    }
}

