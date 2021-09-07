﻿using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Handler.Interfaces
{
    public interface IProductHandler
    {
        #region GET
        public Task<List<ProductViewModel>> GetPizza();
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
