using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Weed DeleteWeed(Weed weed)
        {
            throw new NotImplementedException();
        }

        public Weed ReadWeed(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Weed> ReadWeeds(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Weed UpdateWeed(Weed weed)
        {
            throw new NotImplementedException();
        }
    }
}
