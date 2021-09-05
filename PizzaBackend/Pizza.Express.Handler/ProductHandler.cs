using System.Collections.Generic;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.ViewModels;

namespace Pizza.Express.Handler
{
    public class ProductHandler : IProductHandler
    {
        #region CONSTRUCTOR
        private readonly IProductContext productRepo;
        private readonly IGlobals globals;
        public ProductHandler(IGlobals _globals, 
                                IProductContext productRepo)
        {
            this.productRepo = productRepo;
            this.globals = _globals;
        }
        #endregion

        #region GET
        public async Task<List<PizzaViewModel>> GetPizza() => await productRepo.GetPizza();
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion

    }
}
