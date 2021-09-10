using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Pizza.Express.Shared.Entities;
using System;

namespace Pizza.Express.Context
{
    public class OrderContext: IOrderContext
    {
        #region CONSTRUCTOR
        private readonly SqlContext sqlContext;
        private readonly IGlobals globals;
        public OrderContext(IGlobals _globals,
                                SqlContext _sqlRepo)
        {
            this.sqlContext = _sqlRepo;
            this.globals = _globals;
        }
        #endregion

        #region GET
        public async Task<List<OrderViewModel>> GetOrderList()
        {
            ClientEntity client = await this.globals.GetCurrentClient();
            List<OrderViewModel> orders = await sqlContext.Order.Where(c => c.ClientId == client.ClientId)
                    .Join(sqlContext.OrderStatus,
                        order => order.StatusId,
                        orderStatus => orderStatus.StatusId,
                        (order, orderStatus) => new OrderViewModel
                        {
                            OrderId = order.OrderId,
                            OrderCode = order.OrderCode,
                            OrderStatus = new OrderStatusViewModel 
                            { 
                                StatusId = orderStatus.StatusId, 
                                Description = orderStatus.Description
                            }
                        }).ToListAsync();

            foreach(OrderViewModel order in orders)
            {
                order.ProductItem = await sqlContext.OrderedProduct.Where(op => op.OrderId == order.OrderId)
                        .Join(sqlContext.Product,
                        orderedProduct => orderedProduct.ProductId,
                        product => product.ProductId,
                        (orderedProduct, product) => new OrderedProductItemViewModel
                        {
                            OrderedProductId = orderedProduct.OrderedProductId,
                            ProductItem = new ProductViewModel
                            {
                                ProductId = product.ProductId,
                                Name = product.Name,
                                Description = product.Description,
                                Price = product.Price,
                                ImageLink = product.ImageLink
                            },
                            ProductCount = orderedProduct.ProductCount
                        }).ToListAsync(); 
            }

            return orders;
        }
        #endregion

        #region PUT
        public async Task UpdateOrderStatus(OrderViewModel order)
        {
            OrderEntity orderToUpdate = this.sqlContext.Order.Where(o => o.OrderCode == order.OrderCode)
                                        .Select(o => new OrderEntity 
                                        {
                                            OrderId = o.OrderId,
                                            ClientId = o.ClientId,
                                            StatusId = o.StatusId,
                                            OrderCode = o.OrderCode
                                        }).FirstOrDefault();

            orderToUpdate.StatusId = order.OrderStatus.StatusId;
            this.sqlContext.Attach(orderToUpdate);
            await this.sqlContext.SaveChangesAsync();
        }
        #endregion

        #region POST
        public async Task CreateOrder(List<BasketItemViewModel> basket)
        {
            ClientEntity client = await this.globals.GetCurrentClient();
            OrderEntity orderToCreate = new OrderEntity
            {
                ClientId = client.ClientId,
                StatusId = 1,
                OrderCode = Guid.NewGuid().ToString("N")
            };
              
            await this.sqlContext.Order.AddAsync(orderToCreate);
            await this.sqlContext.SaveChangesAsync();

            foreach (BasketItemViewModel basketItem in basket)
            {
                OrderedProductEntity orderedProducts = new OrderedProductEntity
                {
                    OrderId = orderToCreate.OrderId,
                    ProductId = basketItem.ProductItem.ProductId,
                    ProductCount = basketItem.ProductCount
                };
                await this.sqlContext.OrderedProduct.AddAsync(orderedProducts);

                BasketItemEntity basketItemToRemove = await this.sqlContext.BasketItem.Where(bi => bi.ClientId == client.ClientId && bi.BasketItemId == basketItem.BasketId)
                            .Join(sqlContext.Product,
                                basketItemE => basketItemE.ProductId,
                                productE => productE.ProductId,
                                (basketItemE, productE) => new BasketItemEntity
                                {
                                    BasketItemId = basketItemE.BasketItemId,
                                    ProductId = productE.ProductId,
                                    ProductCount = basketItemE.ProductCount
                                }).FirstOrDefaultAsync();

                this.sqlContext.BasketItem.Remove(basketItemToRemove);
            }
            await this.sqlContext.SaveChangesAsync();
        }
        #endregion

    }
}
