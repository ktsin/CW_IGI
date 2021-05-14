using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using Microsoft.Extensions.Logging;

namespace DAL.Repository.EFCore
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            // или так с более детальной настройкой
            //builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
            //            && level == LogLevel.Information)
            //       .AddConsole();
        });

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
            // modelBuilder.Entity<Order>()
            //     .HasMany<Good>()
            //     .WithMany<Order>();
            modelBuilder.Entity<Good>()
                .HasMany<Order>(e=>e.Orders)
                .WithMany(e => e.Goods);
            modelBuilder.Entity<Store>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.OwnerId);
            modelBuilder.Entity<Store>().HasMany<Good>().WithOne().HasForeignKey(e => e.StoreId);
            modelBuilder.Entity<UserBasket>()
                .HasOne<User>()
                .WithOne();
            modelBuilder.Entity<UserBasket>()
                .HasMany<Good>(p => p.SelectedGoods)
                .WithMany(e=>e.Baskets);
            
            FakeDataGenerator.Init(10);
            
            modelBuilder.Entity<User>().HasData(FakeDataGenerator.Users);
            Thread.Sleep(100);
            modelBuilder.Entity<Store>().HasData(FakeDataGenerator.Stores);
            Thread.Sleep(100);
            modelBuilder.Entity<Managers>().HasData(FakeDataGenerator.Managers);
            modelBuilder.Entity<Message>().HasData(FakeDataGenerator.Messages);
            modelBuilder.Entity<Category>().HasData(FakeDataGenerator.Categories);
            // modelBuilder.Entity<Good>().HasData(FakeDataGenerator.Goods);
            // modelBuilder.Entity<Order>().HasData(FakeDataGenerator.Orders);
        }
    }
}