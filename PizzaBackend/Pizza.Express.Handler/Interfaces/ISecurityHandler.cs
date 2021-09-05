using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Handler.Interfaces
{
    public interface ISecurityHandler
    {
        #region GET
        public Task<List<NavMenuViewModel>> GetNavMenu();
        public Task<ClientViewModel> GetClient();
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
