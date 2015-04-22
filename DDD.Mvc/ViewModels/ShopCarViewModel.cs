using System.Collections.Generic;

namespace DDD.Mvc.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartItemViewModel> Items { get; set; }
    }
}