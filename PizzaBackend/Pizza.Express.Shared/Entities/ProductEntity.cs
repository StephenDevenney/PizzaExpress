
namespace Pizza.Express.Shared.Entities
{
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageLink { get; set; }
    }
}
