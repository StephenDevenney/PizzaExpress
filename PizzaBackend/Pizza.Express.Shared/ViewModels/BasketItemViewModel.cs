
namespace Pizza.Express.Shared.ViewModels
{
    public class BasketItemViewModel
    {
        public int BasketId { get; set; }
        public ProductViewModel ProductItem { get; set; }
        public int ProductCount { get; set; }
    }
}
