using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeedShop.Core.DomainService;
using WeedShop.Core.Entity;
using WeedShop.Core.ExceptionHandling;

namespace WeedShop.Core.ApplicationService.Implementation
{
    public class WeedService : IWeedService
    {
        IWeedRepository _WeedRepository;
        IErrorFactory _errorFactory;

        public WeedService(IWeedRepository weedRepo, IErrorFactory errorFactory)
        {
            _WeedRepository = weedRepo;
            _errorFactory = errorFactory;
        }
        public Weed CreateWeed(Weed weed)
        {
            validateWeed(weed);
            return _WeedRepository.AddWeed(weed);
        }

        public Weed DeleteWeed(Weed weed)
        {
            return _WeedRepository.DeleteWeed(weed);
        }

        public Weed GetWeed(int id)
        {
            if (id <= 0)
            {
                _errorFactory.Invalid("id must be higher than 0");
            }
            return _WeedRepository.ReadWeed(id);
        }

        public List<Weed> GetWeeds(Filter filter)
        {
            if (filter == null)
            {
                return _WeedRepository.ReadWeeds(null).ToList();
            }
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                _errorFactory.Invalid("Current page or items per page must be equal or higher than zero");
            }
            if (((filter.CurrentPage - 1) * filter.ItemsPrPage) >= _WeedRepository.Count())
            {
                _errorFactory.Invalid("Index out of bounds. Current page is too high");
            }
            return _WeedRepository.ReadWeeds(filter).ToList();
        }

        public Weed UpdateWeed(Weed weed)
        {
            validateWeed(weed);
            return _WeedRepository.UpdateWeed(weed);
        }
        private void validateWeed(Weed weed)
        {
            if (weed.Type == null || weed.Type.Id <= 0)
            {
                _errorFactory.Invalid("A weed that is being added must include a type");
            }
            if(weed.Rating <= 0 || weed.Rating >= 6)
            {
                _errorFactory.Invalid("You can only give a rating between 1 and 5");
            }
        }
    }
}
