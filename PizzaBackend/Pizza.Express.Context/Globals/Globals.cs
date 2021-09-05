using Pizza.Express.Context.Interfaces;
using Pizza.Express.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Express.Context
{
    public class Globals: IGlobals
    {
        #region CONSTRUCTOR
        private readonly IHttpContextAccessor httpAccess;
        private readonly SqlContext sqlContext;
        public Globals(IHttpContextAccessor _httpAccess,
                        SqlContext sqlRepo)
        {
            this.httpAccess = _httpAccess;
            this.sqlContext = sqlRepo;
        }
        #endregion

        #region GET
        public async Task<ClientEntity> GetCurrentClient()
        {
            return await sqlContext.Client.Where(u => u.ClientName == this.httpAccess.HttpContext.User.Identity.Name)
                .Join(sqlContext.ClientRole,
                    c => c.ClientId,
                    cr => cr.ClientRoleId,
                    (c, cr) => new ClientEntity
                    {
                        ClientId = c.ClientId,
                        ClientName = c.ClientName,
                        ClientRoleId = cr.ClientRoleId,
                        ClientRoleName = cr.RoleName,
                        IsAuthenticated = this.httpAccess.HttpContext.User.Identity.IsAuthenticated
                    }
                ).FirstOrDefaultAsync();
        }

        public async Task<int> GetClientId()
        {
            ClientEntity client = await this.GetCurrentClient();
            return client.ClientId;
        }
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
