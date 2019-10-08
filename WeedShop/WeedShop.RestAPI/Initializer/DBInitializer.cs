using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeedShop.Core.Entity;
using WeedShop.InfraStructure.SQL;

namespace WeedShop.RestAPI.Initializer
{
    public class DBInitializer
    {
        public static void Seed(WeedShopContext ctx) 
        {
            Core.Entity.Type type1 = new Core.Entity.Type
            {
                TypeName = "Hybrid"
            };
            Core.Entity.Type type2 = new Core.Entity.Type
            {
                TypeName = "Sativa"
            };
            Core.Entity.Type type3 = new Core.Entity.Type
            {
                TypeName = "Indica"
            };

            type1 = ctx.Types.Add(type1).Entity;
            type2 = ctx.Types.Add(type2).Entity;
            type3 = ctx.Types.Add(type3).Entity;

            Weed weed1 = new Weed
            {
                Name = "",

            };
        }
    }
}
