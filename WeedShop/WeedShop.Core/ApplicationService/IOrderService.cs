using System;
using System.Collections.Generic;
using System.Text;
using WeedShop.Core.Entity;

namespace WeedShop.Core.ApplicationService
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Order AddOrder(Order order);
        Order UpdateOrder(Order order);
        Order GetOrder(int id);
        Order DeleteOrder(Order order);
    }
}
