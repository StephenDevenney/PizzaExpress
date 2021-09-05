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
        private readonly IGlobals globals;
        public ProductContext(IGlobals _globals,
                                SqlContext _sqlRepo)
        {
            this.sqlContext = _sqlRepo;
            this.globals = _globals;
        }
        #endregion

        #region GET
        public async Task<List<PizzaViewModel>> GetPizza()
        {
            return await sqlContext.Pizza.Select(res => new PizzaViewModel { Name = res.Name, Description = res.Description, Price = res.Price, ImageLink = res.ImageLink }).ToListAsync();
        }
        #endregion

        #region PUT
        
        #endregion

        #region POST

        #endregion
    }
}
