
namespace Pizza.Express.Shared.Entities
{
    public class OrderEntity
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int StatusId { get; set; }
        public string OrderCode { get; set; }
    }
}
