using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Context.Interfaces
{
    public interface ISecurityContext
    {
        #region GET
        public Task<List<NavMenuViewModel>> GetNavMenu();
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
