using Pizza.Express.Shared.Entities;
using System.Threading.Tasks;

namespace Pizza.Express.Context.Interfaces
{
    public interface IGlobals
    {
        #region GET
        public Task<UserEntity> GetCurrentUser();
        public Task<int> GetUserId();
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
