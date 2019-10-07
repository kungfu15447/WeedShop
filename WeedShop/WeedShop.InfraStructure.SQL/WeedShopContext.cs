using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeedShop.InfraStructure.SQL
{
    public class WeedShopContext : DbContext
    {
        public WeedShopContext(DbContextOptions opt) : base(opt)
        {

        }

        

    }
}
