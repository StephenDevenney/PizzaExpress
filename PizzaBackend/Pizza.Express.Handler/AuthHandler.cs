using Pizza.Express.Context.Interfaces;
using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Handler
{
    public class AuthHandler: IAuthHandler
    {
        #region CONSTRUCTOR
        private readonly IAuthContext authRepo;
        public AuthHandler(IAuthContext authUserRepo)
        {
            this.authRepo = authUserRepo;
        }
        #endregion

        #region GET
        public async Task<ClientViewModel> Authenticate(string clientName) => await authRepo.Authenticate(clientName);

        public async Task<List<ClientViewModel>> GetAllClients() => await authRepo.GetAllClients();

        public async Task<ClientViewModel> GetClientById(int clientId) => await authRepo.GetClientById(clientId);
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
