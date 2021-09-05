using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Shared.Security;
using Pizza.Express.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Pizza.Express.Context
{
    public class AuthContext: IAuthContext
    {
        #region CONSTRUCTOR
        private readonly SqlContext sqlContext;
        private readonly AppSettings config;
        public AuthContext(SqlContext sqlRepo, IOptions<AppSettings> configSettings)
        {
            this.sqlContext = sqlRepo;
            this.config = configSettings.Value;
        }
        #endregion

        #region GET
        public async Task<ClientViewModel> Authenticate(string clientname)
        {
            /* 
             * App doesn't require password protection but validation would happen here in a production application.
            */

            ClientViewModel client = await sqlContext.Client.Where(u => u.ClientName == clientname)
                .Join(sqlContext.ClientRole,
                    c => c.ClientId,
                    cr => cr.ClientRoleId,
                    (c, cr) => new ClientViewModel
                    {
                        ClientName = c.ClientName,
                        ClientRole = new ClientRoleViewModel { ClientRoleId = cr.ClientRoleId, ClientRoleName = cr.RoleName }
                    }
                ).FirstOrDefaultAsync();

            // return null if client not found
            if (client == null)
                return null;

            // Generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, client.ClientName),
                    new Claim(ClaimTypes.Role, client.ClientRole.ClientRoleName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            client.Token = tokenHandler.WriteToken(token);
            client.IsAuthenticated = true;

            return client;
        }

        public async Task<List<ClientViewModel>> GetAllClients()
        {
            return await sqlContext.Client.Join(
                sqlContext.ClientRole,
                c => c.ClientId,
                cr => cr.ClientRoleId,
                (c, cr) => new ClientViewModel
                {
                    ClientName = c.ClientName,
                    ClientRole = new ClientRoleViewModel { ClientRoleId = cr.ClientRoleId, ClientRoleName = cr.RoleName }
                }
            ).ToListAsync();
        }

        public async Task<ClientViewModel> GetClientById(int clientId)
        {
            return await sqlContext.Client.Where(c => c.ClientId == clientId)
                .Join(sqlContext.ClientRole,
                    c => c.ClientId,
                    cr => cr.ClientRoleId,
                    (c, cr) => new ClientViewModel
                    {
                        ClientName = c.ClientName,
                        ClientRole = new ClientRoleViewModel { ClientRoleId = cr.ClientRoleId, ClientRoleName = cr.RoleName }
                    }
                ).FirstOrDefaultAsync();
        }
        #endregion

        #region PUT 

        #endregion

        #region POST

        #endregion
    }
}
