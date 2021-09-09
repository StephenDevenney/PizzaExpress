using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Context.Interfaces
{
    public interface IBasketContext
    {
        #region GET
        public Task<List<BasketItemViewModel>> GetBasket();
        #endregion

        #region PUT
        public Task<List<BasketItemViewModel>> UpdateBasketItem(BasketItemViewModel basketItem);
        #endregion

        #region POST
        public Task AddItemToBasket(BasketItemViewModel basketItem);
        #endregion

        #region DELETE
        public Task DeleteItemFromBasket(BasketItemViewModel basketItem);
        #endregion
    }
}
