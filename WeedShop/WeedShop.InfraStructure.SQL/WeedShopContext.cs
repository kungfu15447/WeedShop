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


        public DbSet<Weed> Weeds { get; set; }
        public DbSet<Type> Types { get; set; }


    }
}
