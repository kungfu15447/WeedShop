using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WeedShop.Core.Entity;
using Type = WeedShop.Core.Entity.Type;

namespace WeedShop.InfraStructure.SQL
{
    public class WeedShopContext : DbContext
    {
        public WeedShopContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Weed>()
                .HasOne(w => w.Type);

            modelBuilder.Entity<Weed>()
                .HasMany(w => w.OrderLines)
                .WithOne(ol => ol.Weed)
                .HasForeignKey(ol => ol.WeedId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderLines)
                .WithOne(ol => ol.Order)
                .HasForeignKey(ol => ol.OrderId);
        }

        public DbSet<Weed> Weeds { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
