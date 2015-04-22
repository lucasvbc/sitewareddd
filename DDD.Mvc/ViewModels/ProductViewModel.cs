using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDD.Mvc.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        public decimal Price { get; set; }
    }
}