using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class MerchantService
    {
        private readonly IGenericRepository<MerchantAccount> merchantReposatyr;

        public MerchantService(IGenericRepository<MerchantAccount> merchantReposatyr)
        {
            this.merchantReposatyr = merchantReposatyr;
        }

        public async Task<decimal> getRefoundToMerchant(int id) { 
            MerchantAccount merchant = await merchantReposatyr.GetByIdAsync(id);
            return  merchant.Refund_Percentage;
        }
    }
}
