
namespace Pizza.Express.Shared.ViewModels
{
    public class BasketItemViewModel
    {
        public int BasketId { get; set; }
        public ProductViewModel Product { get; set; }
        public int ProductCount { get; set; }
    }
}
