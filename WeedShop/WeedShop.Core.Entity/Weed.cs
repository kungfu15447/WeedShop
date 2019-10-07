using System;

namespace WeedShop.Core.Entity
{
    public class Weed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
