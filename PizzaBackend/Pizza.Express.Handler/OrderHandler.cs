using System.Collections.Generic;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.ViewModels;

namespace Pizza.Express.Handler
{
    public class OrderHandler : IOrderHandler
    {
        #region CONSTRUCTOR
        private readonly IOrderContext orderRepo;
        private readonly IGlobals globals;
        public OrderHandler(IGlobals _globals, 
                                IOrderContext orderRepo)
        {
            this.orderRepo = orderRepo;
            this.globals = _globals;
        }
        #endregion

        #region GET
        public async Task<List<OrderViewModel>> GetOrderList() => await orderRepo.GetOrderList();
        #endregion

        #region PUT
        public async Task UpdateOrderStatus(OrderViewModel order) => await orderRepo.UpdateOrderStatus(order);
        #endregion

        #region POST
        public async Task CreateOrder(List<BasketItemViewModel> basket) => await orderRepo.CreateOrder(basket);
        #endregion
    }
}
