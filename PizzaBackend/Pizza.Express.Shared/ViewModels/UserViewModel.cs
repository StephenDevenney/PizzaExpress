using System.ComponentModel.DataAnnotations;

namespace Pizza.Express.Shared.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string Token { get; set; }
        [Required]
        public UserRoleViewModel UserRole { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
