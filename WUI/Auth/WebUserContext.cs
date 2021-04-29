using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace WUI.Auth
{
    public class WebUserContext : IdentityDbContext<WebUser>
    {
        public WebUserContext(DbContextOptions<WebUserContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public new DbSet<WebUser> Users { get; set; }
        
        public new DbSet<WebUserRole> Roles { get; set; }
        
        
    }
}