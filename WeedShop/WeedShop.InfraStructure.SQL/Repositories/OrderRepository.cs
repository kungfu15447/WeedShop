using Microsoft.EntityFrameworkCore;
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
                .Include(o => o.WeedBought)
                .FirstOrDefault(o => o.id == id);
        }

        public IEnumerable<Order> ReadOrders()
        {
            return _context.Orders
                .Include(w => w.WeedBought).ToList();
        }

        public Order UpdateOrder(Order order)
        {
            _context.Attach(order).State = EntityState.Modified;
            _context.Entry(order).Reference(o => o.WeedBought).IsModified = true;
            _context.SaveChanges();
            return order;
        }
    }
}
