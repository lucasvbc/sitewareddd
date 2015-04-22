using System;
using System.Collections.Generic;
using DDD.Application.Interface;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Services;

namespace DDD.Application
{
    public class OfferAppService : AppServiceBase<Offer>, IOfferAppService
    {
        private readonly IOfferService _offerService;
        public OfferAppService(IOfferService offerService) : base(offerService)
        {
            _offerService = offerService;
        }

        public IEnumerable<Offer> GetValidOffers(int amount)
        {
            return _offerService.GetValidOffers(_offerService.GetList(), amount);
        }
    }
}
