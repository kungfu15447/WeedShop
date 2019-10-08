using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeedShop.Core.DomainService;
using WeedShop.Core.Entity;

namespace WeedShop.Core.ApplicationService.Implementation
{
    public class OrderService : IOrderService
    {
        readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Order AddOrder(Order order)
        {
            return _orderRepo.AddOrder(order);
        }

        public Order DeleteOrder(Order order)
        {
            return _orderRepo.DeleteOrder(order);
        }

        public Order GetOrder(int id)
        {
            return _orderRepo.ReadOrder(id);
        }

        public List<Order> GetOrders()
        {
            return _orderRepo.ReadOrders().ToList();
        }

        public Order UpdateOrder(Order order)
        {
            return _orderRepo.UpdateOrder(order);
        }
    }
}
