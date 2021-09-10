using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Context.Interfaces
{
    public interface IOrderContext
    {
        #region GET
        public Task<List<OrderViewModel>> GetOrderList();
        #endregion

        #region PUT
        public Task UpdateOrderStatus(OrderViewModel order);
        #endregion

        #region POST
        public Task CreateOrder(List<BasketItemViewModel> basket);
        #endregion
    }
}
