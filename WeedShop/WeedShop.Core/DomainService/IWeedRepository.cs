using System;
using System.Collections.Generic;
using System.Text;
using WeedShop.Core.Entity;

namespace WeedShop.Core.DomainService
{
    public interface IWeedRepository
    {
        Weed ReadWeed(int id);
        IEnumerable<Weed> ReadWeeds(Filter filter);
        Weed AddWeed(Weed weed);
        Weed DeleteWeed(Weed weed);
        Weed UpdateWeed(Weed weed);
        int Count();

    }
}
