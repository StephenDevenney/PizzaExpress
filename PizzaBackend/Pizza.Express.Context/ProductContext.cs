using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Pizza.Express.Context
{
    public class ProductContext: IProductContext
    {
        #region CONSTRUCTOR
        private readonly SqlContext sqlContext;
        public ProductContext(SqlContext _sqlRepo)
        {
            this.sqlContext = _sqlRepo;
        }
        #endregion

        #region GET
        public async Task<List<ProductViewModel>> GetPizza()
        {
            return await sqlContext.Product.Where(pt => pt.ProductTypeId == 1)
                                            .Select(p => new ProductViewModel
                                            {
                                                ProductId = p.ProductId,
                                                Name = p.Name,
                                                Description = p.Description,
                                                Price = p.Price,
                                                ImageLink = p.ImageLink
                                            }).ToListAsync();
        }
        #endregion

        #region PUT
        
        #endregion

        #region POST

        #endregion
    }
}
