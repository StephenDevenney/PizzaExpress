using System.ComponentModel.DataAnnotations;

namespace Pizza.Express.Shared.ViewModels
{
    public class ClientViewModel
    {
        [Required]
        public string ClientName { get; set; }
        public string Token { get; set; }
        [Required]
        public ClientRoleViewModel ClientRole { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
