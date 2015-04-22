using System;
using System.Collections.Generic;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;
using System.Linq;

namespace DDD.Domain.Services
{
    public class OfferService : ServiceBase<Offer>, IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository) : base(offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IEnumerable<Offer> GetValidOffers(IEnumerable<Offer> offer, int amount)
        {
            return offer.Where(x => x.ValidOffer(x, amount));
        }
    }
}
