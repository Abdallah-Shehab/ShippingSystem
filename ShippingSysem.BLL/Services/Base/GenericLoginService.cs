using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShippingSysem.BLL.DTOs.LoginDTOs;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ShippingSystem.DAL.Repositories.Base;



namespace ShippingSysem.BLL.Services.Base
{
    public class GenericLoginService<T> where T : IdentityUser<int>, IEntity, IAccount
    {
        public IGenericRepository<T> IGenericRepo { get; }
        private readonly UserManager<T> userManagerAccount;
        private readonly GenericLoginReposatry<T> genericLoginReposatry;

        public GenericLoginService(IGenericRepository<T> iGenericRepo,
            UserManager<T> userManagerAccount,
            GenericLoginReposatry<T> genericLoginReposatry)
        {
            this.IGenericRepo = iGenericRepo;
            this.userManagerAccount = userManagerAccount;
            this.genericLoginReposatry = genericLoginReposatry;
        }


        public async Task<MessageOrToken> getTokenEmployee(CreateLoginDTO login, params Expression<Func<T, object>>[] includes)
        {
            //get User By Emial

            var users = await userManagerAccount.Users.ToListAsync();

            var account = await userManagerAccount.FindByEmailAsync(login.Email);
            MessageOrToken messageOrToken;

            if (account != null)
            {
                bool found = await userManagerAccount.CheckPasswordAsync(account, login.Password);
                if (found)
                {
                    T accountWithRole = genericLoginReposatry.GetAccountWithRole(o => o.Id == account.Id, includes);


                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim("Name", account.Name),
                        new Claim("id",account.Id.ToString()),
                        new Claim("roleName",accountWithRole.Role.Name),
                        new Claim("roleId",accountWithRole.Role.Id.ToString()),
                    };

                    var secrite = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Mohamed Hamdy and Abdallah Shafiq and Hala Mansour and Azza Gamel And Mariem Omran"));
                    var signCirdintional = new SigningCredentials(secrite, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(claims: claims, signingCredentials: signCirdintional, expires: DateTime.UtcNow.AddHours(1));
                    //convert token to string 

                    var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);


                    ReadLoginDTO readLoginDTO = new ReadLoginDTO()
                    {

                        token = tokenHandler
                    };
                    return (new MessageOrToken() { ReadLoginDTO = readLoginDTO });
                }
                else
                {
                    //-----------password not valid ---------------
                    return (new MessageOrToken() { Msg = "password Not Valid" });

                }

            }
            else
            {
                //-------------email  not valid-----------------
                //messageOrToken.Msg = "Email Not Valid";
                return (new MessageOrToken() { Msg = "Email Not Valid" });
            }

        }
        //public async Task<string>getTokenMerchant() { }
        //public async Task<string>getTokenDelivery() { }
    }

}