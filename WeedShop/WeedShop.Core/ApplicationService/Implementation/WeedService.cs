using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeedShop.Core.DomainService;
using WeedShop.Core.Entity;

namespace WeedShop.Core.ApplicationService.Implementation
{
    public class WeedService : IWeedService
    {
        IWeedRepository _WeedRepository;

        public WeedService(IWeedRepository weedRepo)
        {
            _WeedRepository = weedRepo;
        }
        public Weed CreateWeed(Weed weed)
        {
           return _WeedRepository.AddWeed(weed);
        }

        public Weed DeleteWeed(Weed weed)
        {
            return _WeedRepository.DeleteWeed(weed);
        }

        public Weed GetWeed(int id)
        {
            return _WeedRepository.ReadWeed(id);
        }

        public List<Weed> GetWeeds()
        {
            return _WeedRepository.ReadWeeds().ToList();
        }

        public Weed UpdateWeed(Weed weed)
        {
            return _WeedRepository.UpdateWeed(weed);
        }
    }
}
