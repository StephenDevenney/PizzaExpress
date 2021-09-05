using System.Collections.Generic;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.Entities;
using Pizza.Express.Shared.ViewModels;

namespace Pizza.Express.Handler
{
    public class SecurityHandler : ISecurityHandler
    {
        #region CONSTRUCTOR
        private readonly ISecurityContext securityRepo;
        private readonly IGlobals globals;
        public SecurityHandler(IGlobals _globals, 
                                ISecurityContext securityRepo)
        {
            this.securityRepo = securityRepo;
            this.globals = _globals;
        }
        #endregion

        #region GET
        public async Task<List<NavMenuViewModel>> GetNavMenu() => await securityRepo.GetNavMenu();
        public async Task<ClientViewModel> GetClient()
        {
            ClientEntity client = await this.globals.GetCurrentUser();
            return new ClientViewModel
            {
                ClientName = client.ClientName,
                ClientRole = new ClientRoleViewModel
                {
                    ClientRoleId = client.ClientRoleId,
                    ClientRoleName = client.ClientRoleName
                },
                Token = "",
                IsAuthenticated = client.IsAuthenticated
            };
        }
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion

    }
}
