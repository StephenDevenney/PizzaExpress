using Pizza.Express.Shared.Entities;
using System.Threading.Tasks;

namespace Pizza.Express.Context.Interfaces
{
    public interface IGlobals
    {
        #region GET
        public Task<ClientEntity> GetCurrentClient();
        public Task<int> GetClientId();
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
