﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeedShop.Core.Entity
{
    public class Order
    {
        public int Id{ get; set; }
        public DateTime OrderDate{ get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<Weed> WeedBought{ get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
