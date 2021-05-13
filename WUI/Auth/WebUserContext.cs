using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WUI.Auth
{
    public sealed class WebUserContext : IdentityDbContext<WebUser>
    {
        public WebUserContext(DbContextOptions<WebUserContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override DbSet<WebUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new List<IdentityRole>()
                {
                    new IdentityRole(){Name ="Admin", Id = Guid.NewGuid().ToString()},
                    new IdentityRole(){Name ="Manager",  Id = Guid.NewGuid().ToString()},
                    new IdentityRole(){Name ="StoreOwner", Id = Guid.NewGuid().ToString()},
                    new IdentityRole(){Name ="Basic", Id = Guid.NewGuid().ToString()},
                });
        }
    }
}