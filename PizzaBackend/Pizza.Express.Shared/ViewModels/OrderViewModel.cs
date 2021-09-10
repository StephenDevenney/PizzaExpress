
using System.Collections.Generic;

namespace Pizza.Express.Shared.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public List<OrderedProductItemViewModel> ProductItem { get; set; }
        public string OrderCode { get; set; }
        public OrderStatusViewModel OrderStatus { get; set; }
    }
}
