using System;
using System.Collections.Generic;
using System.Text;

namespace WeedShop.Core.Entity
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int WeedId { get; set; }
        public Weed Weed{ get; set; }
        public int OrderId { get; set; }
        public Order Order{ get; set; }
        public int Qty { get; set; }
        public double PriceWhenBought { get; set; }
    }
}
