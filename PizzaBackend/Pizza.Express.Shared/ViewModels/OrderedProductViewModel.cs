
namespace Pizza.Express.Shared.ViewModels
{
    public class OrderedProductItemViewModel
    {
        public int OrderedProductId { get; set; }
        public ProductViewModel ProductItem { get; set; }
        public int ProductCount { get; set; }
    }
}
