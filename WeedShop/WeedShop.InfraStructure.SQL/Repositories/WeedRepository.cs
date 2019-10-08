using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeedShop.Core.DomainService;
using WeedShop.Core.Entity;

namespace WeedShop.InfraStructure.SQL.Repositories
{
    public class WeedRepository : IWeedRepository
    {

        private WeedShopContext _context;

        public WeedRepository(WeedShopContext context)
        {
           _context = context;
        }

        public Weed AddWeed(Weed weed)
        {
            _context.Attach(weed).State = EntityState.Added;
            _context.SaveChanges();
            return weed;
        }

        public int Count()
        {
            return _context.Weeds.Count();
        }

        public Weed DeleteWeed(Weed weed)
        {
            _context.Remove(weed);
            _context.SaveChanges();
            return weed;
        }

        public Weed ReadWeed(int id)
        {
            return _context.Weeds
                .Include(w => w.Type)
                .Include(w => w.OrderLines)
                .ThenInclude(ol => ol.Order)
                .FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Weed> ReadWeeds(Filter filter)
        {
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                var filteredList = _context.Weeds
                    .Include(w => w.Type)
                    .Include(w => w.OrderLines)
                    .ThenInclude(ol => ol.Order)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
                return filteredList.ToList();
            }
            return _context.Weeds
                .Include(w => w.Type)
                .Include(w => w.OrderLines)
                .ThenInclude(ol => ol.Order)
                .ToList();
        }

        public Weed UpdateWeed(Weed weed)
        {
            _context.Attach(weed).State = EntityState.Modified;
            var orderLines = new List<OrderLine>(weed.OrderLines ?? new List<OrderLine>());
            _context.OrderLines.RemoveRange(
                _context.OrderLines.Where(ol => ol.WeedId == weed.Id));
            foreach (var item in orderLines)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();
            return weed;
        }
    }
}
