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

            modelBuilder.Entity<OrderLine>()
                .HasKey(ol => new { ol.WeedId, ol.OrderId });

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Order)
                .WithMany(o => o.OrderLines)
                .HasForeignKey(ol => ol.OrderId);

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Weed)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ol => ol.WeedId);
        }

        public DbSet<Weed> Weeds { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
