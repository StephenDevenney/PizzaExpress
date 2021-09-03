
namespace Pizza.Express.Shared.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string UserName { get; set; }
        public string UserRoleName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
