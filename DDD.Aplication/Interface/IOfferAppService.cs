using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Application.Interface
{
    public interface IOfferAppService : IAppServiceBase<Offer>
    {
        IEnumerable<Offer> GetValidOffers(int amount);
    }
}
