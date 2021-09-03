﻿using Pizza.Express.Context.Interfaces;
using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza.Express.Handler
{
    public class AuthHandler: IAuthHandler
    {
        #region CONSTRUCTOR
        private readonly IAuthContext authRepo;
        public AuthHandler(IAuthContext authUserRepo)
        {
            this.authRepo = authUserRepo;
        }
        #endregion

        #region GET
        public async Task<UserViewModel> Authenticate(string username) => await authRepo.Authenticate(username);

        public async Task<List<UserViewModel>> GetAllUsers() => await authRepo.GetAllUsers();

        public async Task<UserViewModel> GetUserById(int userId) => await authRepo.GetUserById(userId);
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
