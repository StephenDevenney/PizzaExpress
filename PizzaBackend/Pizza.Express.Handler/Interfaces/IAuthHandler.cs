using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Handler.Interfaces
{
    public interface IAuthHandler
    {
        #region GET
        public Task<ClientViewModel> Authenticate(string clientName);
        public Task<List<ClientViewModel>> GetAllClients();
        public Task<ClientViewModel> GetClientById(int userId);
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
