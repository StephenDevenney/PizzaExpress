using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.Security;
using Pizza.Express.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.API.Controllers
{
    [Route("Order")]
    public class OrderController : ControllerBase
    {
        #region CONSTRUCTOR
        private readonly IOrderHandler orderHandler;
        public OrderController(IOrderHandler orderHandler)
        {
            this.orderHandler = orderHandler;
        }
        #endregion

        #region GET
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("order-list")]
        public async Task<List<OrderViewModel>> GetOrderList() => await orderHandler.GetOrderList();
        #endregion

        #region PUT 
        [Authorize(Roles = SecureRole.Admin)]
        [HttpPut("order-status")]
        public async Task UpdateOrderStatus([FromBody] OrderViewModel order) => await orderHandler.UpdateOrderStatus(order);
        #endregion

        #region POST
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpPost("create-order")]
        public async Task CreateOrder([FromBody] List<BasketItemViewModel> basket) => await orderHandler.CreateOrder(basket);
        #endregion

        #region DELETE

        #endregion
    }
}
