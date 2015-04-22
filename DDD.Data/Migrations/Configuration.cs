namespace DDD.Data.Migrations
{
    using System;
    using Domain.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.DatabaseContext context)
        {
            context.Products.AddOrUpdate(
                    p => p.ProductId,
                    new Product { Name = "Chuteira 1", Price = 10.90M },
                    new Product { Name = "Chuteira 2", Price = 0.90M },
                    new Product { Name = "Chuteira 3", Price = 14.50m }
                );
            context.Offer.AddOrUpdate(
                o => o.OfferId,
                new Offer { Name = "3 por 10 reais", Price = 10M, Amount = 3 },
                new Offer { Name = "Pague 1 e leve 2", Price = 0.90M, PriceBasedOnProduct = true, NumberOfProductsPriceBased = 1, Amount = 2 }
            );
        }
    }
}
