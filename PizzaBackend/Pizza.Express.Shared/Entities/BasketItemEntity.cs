
namespace Pizza.Express.Shared.Entities
{
    public class BasketItemEntity
    {
        public int BasketItemId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
