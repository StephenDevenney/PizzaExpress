using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.Security;
using Pizza.Express.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.API.Controllers
{
    [Route("Security")]
    public class SecurityController : ControllerBase
    {
        #region CONSTRUCTOR
        private readonly ISecurityHandler securityHandler;
        public SecurityController(ISecurityHandler securityHandler)
        {
            this.securityHandler = securityHandler;
        }
        #endregion

        #region GET
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("nav-menu")]
        public async Task<List<NavMenuViewModel>> GetNavMenu() => await securityHandler.GetNavMenu();
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("client")]
        public async Task<ClientViewModel> GetClient() => await securityHandler.GetClient();
        #endregion

        #region PUT 

        #endregion

        #region POST

        #endregion
    }
}
