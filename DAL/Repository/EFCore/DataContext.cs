using System;
using System.Collections.Generic;
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
            #region MessageConfig

            modelBuilder.Entity<Message>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.RecipientId);
            modelBuilder.Entity<Message>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.SenderId);

            #endregion

            #region GoodConfig

            modelBuilder.Entity<Good>()
                .HasOne<Store>()
                .WithMany()
                .HasForeignKey(p => p.StoreId);
            modelBuilder.Entity<Good>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Good>()
                .HasMany<Order>(e => e.Orders)
                .WithMany(e => e.Goods);
            modelBuilder.Entity<Good>()
                .HasOne<Store>()
                .WithMany()
                .HasForeignKey(p => p.StoreId);

            #endregion

            #region ManagersConfig

            modelBuilder.Entity<Managers>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId);

            #endregion

            #region OrderConfig

            modelBuilder.Entity<Order>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId);
            // modelBuilder.Entity<Order>()
            //     .HasMany<Good>(e => e.Goods)
            //     .WithMany(e => e.Orders);

            #endregion

            #region StoreConfig

            modelBuilder.Entity<Store>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.OwnerId);
            // modelBuilder.Entity<Store>()
            //     .HasMany<Good>()
            //     .WithOne()
            //     .HasForeignKey(e => e.StoreId);

            #endregion

            #region UserBasketConfig

            modelBuilder.Entity<UserBasket>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<UserBasket>(e => e.UserId);
            modelBuilder.Entity<UserBasket>()
                .HasMany<Good>(p => p.SelectedGoods)
                .WithMany(e => e.Baskets);

            #endregion

            #region OrderConfig

            modelBuilder.Entity<Order>()
                .HasMany<Good>(e => e.Goods)
                .WithMany(e => e.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderGood",
                    j => j
                        .HasOne<Good>()
                        .WithMany()
                        .HasForeignKey("GoodId")
                        .HasConstraintName("FK_OrderGood_Goods_GoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired(false),
                    j => j
                        .HasOne<Order>()
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderGood_Orders_OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired(false)
                );
            // modelBuilder.Entity<Order>()
            //     .HasOne<User>()
            //     .WithMany()
            //     .HasForeignKey(e => e.UserId);

            #endregion

            #region UserConfig



            #endregion

            #region FakerConfig

            FakeDataGenerator.Init(10);

            modelBuilder.Entity<User>().HasData(FakeDataGenerator.Users);
            modelBuilder.Entity<Store>().HasData(FakeDataGenerator.Stores);
            modelBuilder.Entity<Managers>().HasData(FakeDataGenerator.Managers);
            modelBuilder.Entity<Message>().HasData(FakeDataGenerator.Messages);
            modelBuilder.Entity<Category>().HasData(FakeDataGenerator.Categories);
            modelBuilder.Entity<Good>().HasData(FakeDataGenerator.Goods);

            #endregion
        }
    }
}