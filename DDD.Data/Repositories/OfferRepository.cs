using System;
using System.Collections.Generic;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using System.Linq;

namespace DDD.Data.Repositories
{
    public class OfferRepository : RepositoryBase<Offer>, IOfferRepository
    {
    }
}
