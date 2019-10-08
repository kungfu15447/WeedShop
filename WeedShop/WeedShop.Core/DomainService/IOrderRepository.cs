using System;
using System.Collections.Generic;
using System.Text;
using WeedShop.Core.Entity;

namespace WeedShop.Core.DomainService
{
    public interface IOrderRepository
    {
        Order ReadOrder(int id);
        IEnumerable<Order> ReadOrders();
        Order AddOrder(Order order);
        Order DeleteOrder(Order order);
        Order UpdateOrder(Order order);
    }
}
