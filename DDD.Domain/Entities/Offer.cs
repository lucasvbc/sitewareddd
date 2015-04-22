using System;

namespace DDD.Domain.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public bool? PriceBasedOnProduct { get; set; }
        public int? NumberOfProductsPriceBased { get; set; }

        public bool ValidOffer(Offer offer, int amount)
        {
            return offer.Amount == amount;
        }
    }
}
