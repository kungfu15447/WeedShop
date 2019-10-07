using System;
using System.Collections.Generic;
using System.Text;
using WeedShop.Core.Entity;

namespace WeedShop.Core.DomainService
{
    public interface IWeedService
    {
        List<Weed> GetWeeds();
        Weed CreateWeed(Weed weed);
        Weed UpdateWeed(Weed weed);
        Weed DeleteWeed(Weed weed);
        Weed GetWeed(Weed weed);

        


    }
}
