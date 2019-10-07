using System;
using System.Collections.Generic;
using System.Text;
using WeedShop.Core.Entity;

namespace WeedShop.Core.DomainService
{
    public interface IWeedService
    {
        List<Weed> GetWeeds(Filter filter);
        Weed CreateWeed(Weed weed);
        Weed UpdateWeed(Weed weed);
        Weed DeleteWeed(Weed weed);
        Weed GetWeed(int id);

        


    }
}
