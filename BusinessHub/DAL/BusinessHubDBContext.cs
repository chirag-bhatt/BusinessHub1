using BusinessHub.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHub.DAL
{
    public class BusinessHubDBContext : DbContext
    {
        public BusinessHubDBContext(DbContextOptions<BusinessHubDBContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<UserInfo> UserInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasData(new UserInfo
            {
                UserId = Guid.NewGuid(),
                FirstName = "Admin",
                LastName = "User",
                UserName = "Admin",
                Password = "Admin@123"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
