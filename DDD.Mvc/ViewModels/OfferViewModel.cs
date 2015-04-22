using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.Mvc.ViewModels
{
    public class OfferViewModel
    {
        [Key]
        public int OfferId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "999999999999")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public bool? PriceBasedOnProduct { get; set; }
        public int? NumberOfProductsPriceBased { get; set; }

    }
}