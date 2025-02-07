﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeedShop.Core.DomainService;
using WeedShop.Core.Entity;

namespace WeedShop.InfraStructure.SQL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private WeedShopContext _context;

        public OrderRepository(WeedShopContext context)
        {
            _context = context;
        }

        public Order AddOrder(Order order)
        {
            _context.Attach(order).State = EntityState.Added;
            _context.SaveChanges();
            return order;
        }

        public Order DeleteOrder(Order order)
        {
            _context.Remove(order);
            _context.SaveChanges();
            return order;
        }

        public Order ReadOrder(int id)
        {
            return _context.Orders
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Weed)
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> ReadOrders()
        {
            return _context.Orders
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Weed)
                .ToList();
        }

        public Order UpdateOrder(Order order)
        {
            _context.Attach(order).State = EntityState.Modified;
            var orderLines = new List<OrderLine>(order.OrderLines ?? new List<OrderLine>());
            _context.OrderLines.RemoveRange(
                _context.OrderLines.Where(ol => ol.OrderId == order.Id));
            foreach (var item in orderLines)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();
            return order;
        }
    }
}
