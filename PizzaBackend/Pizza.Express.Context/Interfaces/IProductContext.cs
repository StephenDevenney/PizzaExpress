using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Context.Interfaces
{
    public interface IProductContext
    {
        #region GET
        public Task<List<PizzaViewModel>> GetPizza();
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
