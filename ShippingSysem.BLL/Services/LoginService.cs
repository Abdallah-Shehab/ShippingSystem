using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShippingSysem.BLL.DTOs.LoginDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace ShippingSysem.BLL.Services
{
	public class LoginService
	{
        /// <summary>
        /// we need create Generic Service 
		/// and 
		/// return Role Name When USer Enter Right Password and Email   
        /// 
        /// </summary>
        private readonly UserManager<Account> userManagerAccount;
        private readonly UserManager<MerchantAccount> userManagerMerchant;
        private readonly UserManager<DeliveryAccount> userManagerDelivery;

        public IGenericRepository<Account> IGenericRepo { get; }
        public LoginService(IGenericRepository<Account> iGenericRepo,
            UserManager<Account> userManagerAccount,
            UserManager<MerchantAccount> userManagerMerchant,
			UserManager<DeliveryAccount> userManagerDelivery)
        {
			IGenericRepo = iGenericRepo;
            this.userManagerAccount = userManagerAccount;
            this.userManagerMerchant = userManagerMerchant;
            this.userManagerDelivery = userManagerDelivery;
        }

		//public Task<bool> Login(string email,string password)
		//{
		//	var userCheck = CheckAcc(email, password);
		//	if (userCheck == "email isn't exist")
		//	{
		//		return Ok("email isn't exist");
		//	}
		//	else if (userCheck == "password is wrong")
		//	{
		//		return Ok("password is wrong");
		//	}
		//}
		public string CheckAcc(string email,string password)
		{
			var user = IGenericRepo.GetAllWithFilter(x => x.Email == email).Result.FirstOrDefault();
			if (user == null)
			{
				return "email isn't exist";
			}
			else
			{
				var checkPass = IGenericRepo.GetAllWithFilter(x => x.Email == email && x.PasswordHash==password).Result.FirstOrDefault(); 
				if (checkPass == null)
				{
					return "password is wrong";
				}
				else
				{
					return "email & pass correct";
				}
			}
		}


		public async Task<MessageOrToken> getTokenEmployee(CreateLoginDTO login) {
            //get User By Emial


            var account = await userManagerAccount.FindByEmailAsync(login.Email);
            MessageOrToken messageOrToken ;
			
			if (account != null) {
				bool found = await userManagerAccount.CheckPasswordAsync(account, login.Password);
				if (found) {

					List<Claim> claims = new List<Claim>();
					claims.Add(new Claim("userName", account.UserName));
                    var secrite = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Mohamed Hamdy and Abdallah Shafiq and Hala Mansour and Azza Gamel And Mariem Omran"));
                    var signCirdintional = new SigningCredentials(secrite, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(claims: claims, signingCredentials: signCirdintional);
                    //convert token to string 
                    var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
					ReadLoginDTO readLoginDTO = new ReadLoginDTO() {
						id = account.Id,
						Name=account.Name,
						//Role=account.Role.Name,
						token=tokenHandler
					};
                    return (new MessageOrToken() { ReadLoginDTO = readLoginDTO });
                }
				else {
                    //-----------password not valid ---------------
                    return (new MessageOrToken() { Msg = "password Not Valid" });

                }

			}
			else {
                //-------------email  not valid-----------------
                //messageOrToken.Msg = "Email Not Valid";
                return  (new MessageOrToken() { Msg = "Email Not Valid" });
            }
		
		}
		//public async Task<string>getTokenMerchant() { }
		//public async Task<string>getTokenDelivery() { }
	}
}
