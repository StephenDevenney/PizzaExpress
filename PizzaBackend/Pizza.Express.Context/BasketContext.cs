using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Pizza.Express.Shared.Entities;

namespace Pizza.Express.Context
{
    public class BasketContext: IBasketContext
    {
        #region CONSTRUCTOR
        private readonly SqlContext sqlContext;
        private readonly IGlobals globals;
        public BasketContext(IGlobals _globals,
                                SqlContext _sqlRepo)
        {
            this.sqlContext = _sqlRepo;
            this.globals = _globals;
        }
        #endregion

        #region GET
        public async Task<List<BasketItemViewModel>> GetBasket()
        {
            ClientEntity client = await this.globals.GetCurrentClient();
            return await sqlContext.BasketItem.Where(c => c.ClientId == client.ClientId)
            .Join(sqlContext.Product,
                basketItem => basketItem.ProductId,
                product => product.ProductId,
                (basketItem, product) => new BasketItemViewModel
                {
                    BasketId = basketItem.BasketItemId,
                    ProductItem = new ProductViewModel 
                    { 
                        ProductId = product.ProductId, 
                        Name = product.Name, 
                        Description = product.Description, 
                        Price = product.Price, 
                        ImageLink = product.ImageLink 
                    },
                    ProductCount = basketItem.ProductCount
                }).ToListAsync();
        }
        #endregion

        #region PUT
        public async Task<List<BasketItemViewModel>> UpdateBasketItem(BasketItemViewModel basketItem)
        {
            BasketItemEntity basketItemToUpdate = await this.FindBasketItem(basketItem);
            basketItemToUpdate.ProductId = basketItem.ProductItem.ProductId;
            basketItemToUpdate.ProductCount = basketItem.ProductCount;
            this.sqlContext.Attach(basketItemToUpdate);
            await this.sqlContext.SaveChangesAsync();
            return await this.GetBasket();
        }
        #endregion

        #region POST
        public async Task AddItemToBasket(BasketItemViewModel basketItem)
        {
            ClientEntity client = await this.globals.GetCurrentClient();
            BasketItemEntity basketItemToAdd = new BasketItemEntity
            {
                ClientId = client.ClientId,
                ProductId = basketItem.ProductItem.ProductId,
                ProductCount = basketItem.ProductCount
            };
            await this.sqlContext.BasketItem.AddAsync(basketItemToAdd);
            await this.sqlContext.SaveChangesAsync();
        }
        #endregion

        #region DELETE
        public async Task DeleteItemFromBasket(BasketItemViewModel basketItem)
        {
            BasketItemEntity basketItemToRemove = await this.FindBasketItem(basketItem);
            this.sqlContext.BasketItem.Remove(basketItemToRemove);
            await this.sqlContext.SaveChangesAsync();
        }
        #endregion

        #region SHARED
        private async Task<BasketItemEntity> FindBasketItem(BasketItemViewModel basketItem)
        {
            ClientEntity client = await this.globals.GetCurrentClient();
            return await this.sqlContext.BasketItem.Where(bi => bi.ClientId == client.ClientId && bi.BasketItemId == basketItem.BasketId)
                .Join(sqlContext.Product,
                    basketItemE => basketItemE.ProductId,
                    productE => productE.ProductId,
                    (basketItemE, productE) => new BasketItemEntity 
                    { 
                        BasketItemId = basketItemE.BasketItemId,
                        ProductId = productE.ProductId,
                        ProductCount = basketItemE.ProductCount
                    }).FirstOrDefaultAsync();
        }
        #endregion
    }
}
