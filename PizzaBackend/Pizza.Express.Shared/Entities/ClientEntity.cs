
namespace Pizza.Express.Shared.Entities
{
    public class ClientEntity
    {
        public int ClientId { get; set; }
        public int ClientRoleId { get; set; }
        public string ClientName { get; set; }
        public string ClientRoleName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
