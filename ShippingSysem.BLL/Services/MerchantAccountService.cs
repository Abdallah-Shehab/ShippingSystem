using ShippingSysem.BLL.DTOs.DeliveryDTOS;
using ShippingSysem.BLL.DTOs.MerchantDTOS;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class MerchantAccountService
    {
        private readonly IGenericRepository<MerchantAccount> genRepo;
        public MerchantAccountService(IGenericRepository<MerchantAccount> genRepo) {
            this.genRepo = genRepo;
        }




        //method to Display All Merchant Accounts
        public async Task<List<DisplayMerchantAccountsDTO>> GetAllMerchantAccounts()
        {
            var accounts = await genRepo.GetAllAsync();
            var dtos = accounts
                .Select(acc => new DisplayMerchantAccountsDTO
                {
                    ID=acc.Id,
                    Name = acc.Name,
                    email = acc.Email,
                    password = acc.PasswordHash,
                    Branch = acc.Branch.Name,
                    Address = acc.Address,
                    StoreName = acc.StoreName,
                    Government = acc.Government,
                    City = acc.City,
                    Pickup_Price = acc.Pickup_Price,
                    Refund_Percentage = acc.Id,

                })
                .ToList();

            return dtos;
        }


    }
}
