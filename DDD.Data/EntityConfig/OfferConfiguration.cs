using DDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DDD.Data.EntityConfig
{
    public class OfferConfiguration : EntityTypeConfiguration<Offer>
    {
        public OfferConfiguration()
        {
            Property(p => p.Name).IsRequired();
            Property(p => p.Price).IsRequired();
            Property(p => p.Amount).IsRequired();
        }
    }
}
