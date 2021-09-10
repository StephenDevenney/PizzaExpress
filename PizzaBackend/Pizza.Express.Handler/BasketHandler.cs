using System.Collections.Generic;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.ViewModels;

namespace Pizza.Express.Handler
{
    public class BasketHandler : IBasketHandler
    {
        #region CONSTRUCTOR
        private readonly IBasketContext basketRepo;
        public BasketHandler(IBasketContext basketRepo)
        {
            this.basketRepo = basketRepo;
        }
        #endregion

        #region GET
        public async Task<List<BasketItemViewModel>> GetBasket() => await basketRepo.GetBasket();
        #endregion

        #region PUT
        public async Task<List<BasketItemViewModel>> UpdateBasketItem(BasketItemViewModel basketItem) => await basketRepo.UpdateBasketItem(basketItem);
        #endregion

        #region POST
        public async Task AddItemToBasket(BasketItemViewModel basketItem) => await basketRepo.AddItemToBasket(basketItem);
        #endregion

        #region DELETE
        public async Task DeleteItemFromBasket(BasketItemViewModel basketItem) => await basketRepo.DeleteItemFromBasket(basketItem);
        #endregion
    }
}
