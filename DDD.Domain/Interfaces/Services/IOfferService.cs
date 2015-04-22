using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Domain.Interfaces.Services
{
    public interface IOfferService : IServiceBase<Offer>
    {
        IEnumerable<Offer> GetValidOffers(IEnumerable<Offer> offer, int amount);
    }
}
