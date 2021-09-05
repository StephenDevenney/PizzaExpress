using System.Collections.Generic;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.ViewModels;

namespace Pizza.Express.Handler
{
    public class SecurityHandler : ISecurityHandler
    {
        #region CONSTRUCTOR
        private readonly ISecurityContext securityRepo;
        public SecurityHandler(ISecurityContext securityRepo)
        {
            this.securityRepo = securityRepo;
        }
        #endregion

        #region GET
        public async Task<List<NavMenuViewModel>> GetNavMenu() => await securityRepo.GetNavMenu();
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion

    }
}
