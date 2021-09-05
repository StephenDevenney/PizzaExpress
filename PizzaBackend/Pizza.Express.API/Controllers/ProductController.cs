using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.Security;
using Pizza.Express.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.API.Controllers
{
    [Route("Products")]
    public class ProductController : ControllerBase
    {
        #region CONSTRUCTOR
        private readonly IProductHandler productHandler;
        public ProductController(IProductHandler productHandler)
        {
            this.productHandler = productHandler;
        }
        #endregion

        #region GET
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("pizza")]
        public async Task<List<PizzaViewModel>> GetPizza() => await productHandler.GetPizza();
        #endregion

        #region PUT 

        #endregion

        #region POST

        #endregion
    }
}
