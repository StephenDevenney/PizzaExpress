
namespace Pizza.Express.Shared.Entities
{
    public class OrderedProductEntity
    {
        public int OrderedProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
