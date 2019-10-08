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
                Name = "Pineapple Express",
                Type = type1,
                Weight = 600,
                Price = 2650.50,
                Description = "This is some good pineapple",
                Rating = 3
            };
            Weed weed2 = new Weed
            {
                Name = "Exodus Cheese",
                Type = type1,
                Weight = 20,
                Price = 3000,
                Description = "Apperently Cheese",
                Rating = 5
            };
            Weed weed3 = new Weed
            {
                Name = "Banana Kush",
                Type = type3,
                Weight = 275,
                Price = 4500,
                Description = "Wtf is this name",
                Rating = 2
            };
            Weed weed4 = new Weed
            {
                Name = "Alice in Wonderland",
                Type = type2,
                Weight = 321,
                Price = 550,
                Description = "Disney approves",
                Rating = 4
            };
            Weed weed5 = new Weed
            {
                Name = "Alaskan Thunder Fuck",
                Type = type2,
                Weight = 1000,
                Price = 45000,
                Description = "THUNDER FUCK THUNDER FUCK THUNDER FUCK THUNDER FUCK",
                Rating = 5
            };
            Weed weed6 = new Weed
            {
                Name = "Pitbull",
                Type = type3,
                Weight = 2,
                Price = 200,
                Description = "TIMBEEEERRRR MR WORLD WIDE AAWWW YEEAAAG",
                Rating = 1
            };

            weed1 = ctx.Weeds.Add(weed1).Entity;
            weed2 = ctx.Weeds.Add(weed2).Entity;
            weed3 = ctx.Weeds.Add(weed3).Entity;
            weed4 = ctx.Weeds.Add(weed4).Entity;
            weed5 = ctx.Weeds.Add(weed5).Entity;
            weed6 = ctx.Weeds.Add(weed6).Entity;

            ctx.SaveChanges();

        }
    }
}
