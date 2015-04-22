using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DDD.Mvc.ViewModels
{
    public class ShoppingCartItemViewModel
    {
        [Key]
        public Guid ShoppingCartItemId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        [JsonProperty(PropertyName = "ProductName")]
        public string ProductName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        public decimal Price { get; set; }

        public int OfferId { get; set; }
    }
}