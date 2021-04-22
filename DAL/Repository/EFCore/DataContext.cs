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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Good> Goods { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Managers> Managers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Order> OrderHistory { get; set; }

        public DbSet<Message> Messages { get; set; }
        
        public DbSet<UserBasket> UserBaskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.RecipientId);
            modelBuilder.Entity<Message>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.SenderId);
            modelBuilder.Entity<Good>()
                .HasOne<Store>()
                .WithMany()
                .HasForeignKey(p => p.StoreId);
            modelBuilder.Entity<Good>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Managers>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Order>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Store>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.OwnerId);
            modelBuilder.Entity<UserBasket>()
                .HasOne<User>()
                .WithOne();
            modelBuilder.Entity<UserBasket>()
                .HasMany<Good>(p=>p.SelectedGoods)
                .WithMany(p=>p.InBaskets);
        }
    }
}