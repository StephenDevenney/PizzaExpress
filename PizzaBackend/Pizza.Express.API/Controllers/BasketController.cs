using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.Security;
using Pizza.Express.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.API.Controllers
{
    [Route("Basket")]
    public class BasketController : ControllerBase
    {
        #region CONSTRUCTOR
        private readonly IBasketHandler basketHandler;
        public BasketController(IBasketHandler basketHandler)
        {
            this.basketHandler = basketHandler;
        }
        #endregion

        #region GET
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("basket-products")]
        public async Task<List<BasketItemViewModel>> GetBasket() => await basketHandler.GetBasket();
        #endregion

        #region PUT 
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpPut("update-product")]
        public async Task<List<BasketItemViewModel>> UpdateBasketItem([FromBody] BasketItemViewModel basketItem) => await basketHandler.UpdateBasketItem(basketItem);
        #endregion

        #region POST
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpPost("add-product")]
        public async Task<List<BasketItemViewModel>> AddItemToBasket([FromBody] BasketItemViewModel basketItem) => await basketHandler.AddItemToBasket(basketItem);
        #endregion

        #region POST
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpDelete("remove-product")]
        public async Task DeleteItemFromBasket([FromBody] BasketItemViewModel basketItem) => await basketHandler.DeleteItemFromBasket(basketItem);
        #endregion
    }
}
