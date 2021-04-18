using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.Repository.EFCore
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Good> Goods { get; set; }
        
        public DbSet<Store> Stores { get; set; }

        public DbSet<Managers> Managers { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Order> OrderHistory { get; set; } 
    }
}