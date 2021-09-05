using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.Security;
using Pizza.Express.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Auth.Controllers
{
    [Route("Auth")]
    public class AuthController : ControllerBase
    {
        #region CONSTRUCTOR
        private readonly IAuthHandler authHandler;
        public AuthController(IAuthHandler authHandler)
        {
            this.authHandler = authHandler;
        }
        #endregion

        #region GET
        [Authorize(Roles = SecureRole.Admin)]
        [HttpGet("all-clients")]
        public async Task<List<ClientViewModel>> GetAllUsers() => await authHandler.GetAllClients();

        [AllowAnonymous]
        [HttpGet("authenticate/{clientName}")]
        public async Task<ClientViewModel> Authenticate(string clientName) => await authHandler.Authenticate(clientName);
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
