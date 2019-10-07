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
                .FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Weed> ReadWeeds(Filter filter)
        {
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                var filteredList = _context.Weeds
                    .Include(w => w.Type)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
                return filteredList.ToList();
            }
            return _context.Weeds
                .Include(w => w.Type).ToList();
        }

        public Weed UpdateWeed(Weed weed)
        {
            _context.Attach(weed).State = EntityState.Modified;
            _context.Entry(weed).Reference(c => c.Type).IsModified = true;
            _context.SaveChanges();
            return weed;
        }
    }
}
