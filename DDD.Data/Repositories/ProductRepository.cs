using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;

namespace DDD.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
    }
}
