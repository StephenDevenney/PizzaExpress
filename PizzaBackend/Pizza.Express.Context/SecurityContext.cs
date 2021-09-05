using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Shared.Entities;
using Pizza.Express.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Pizza.Express.Context
{
    public class SecurityContext: ISecurityContext
    {
        #region CONSTRUCTOR
        private readonly SqlContext sqlContext;
        private readonly IGlobals globals;
        public SecurityContext(IGlobals _globals,
                                SqlContext _sqlRepo)
        {
            this.sqlContext = _sqlRepo;
            this.globals = _globals;
        }
        #endregion

        #region GET
        public async Task<List<NavMenuViewModel>> GetNavMenu()
        {
            UserEntity user = await this.globals.GetCurrentUser();
            return await sqlContext.NavMenu.Join(sqlContext.NavMenuRole.Where(nmr => nmr.UserRoleId == user.UserRoleId),
                nm => nm.NavMenuId,
                nmr => nmr.NavMenuId,
                (nm, nmr) => new NavMenuViewModel
                {
                    NavMenuName = nm.NavMenuName,
                    NavMenuTitle = nm.NavMenuTitle,
                    NavMenuRoute = nm.NavMenuRoute
                }).ToListAsync();
        }
        #endregion

        #region PUT
        
        #endregion

        #region POST

        #endregion
    }
}
