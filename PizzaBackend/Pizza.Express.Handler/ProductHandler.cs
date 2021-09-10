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
        public ProductHandler(IProductContext productRepo)
        {
            this.productRepo = productRepo;
        }
        #endregion

        #region GET
        public async Task<List<ProductViewModel>> GetPizza() => await productRepo.GetPizza();
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion

    }
}
