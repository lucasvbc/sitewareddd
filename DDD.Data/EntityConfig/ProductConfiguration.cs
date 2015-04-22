using DDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DDD.Data.EntityConfig
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Name).IsRequired();
        }
    }
}
