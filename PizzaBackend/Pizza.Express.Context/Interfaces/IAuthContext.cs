using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Context.Interfaces
{
    public interface IAuthContext
    {
        #region GET
        public Task<ClientViewModel> Authenticate(string clientName);
        public Task<List<ClientViewModel>> GetAllClients();
        public Task<ClientViewModel> GetClientById(int clientId);
        #endregion

        #region PUT 

        #endregion

        #region POST

        #endregion
    }
}
