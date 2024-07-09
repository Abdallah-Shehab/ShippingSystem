﻿using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Repositories
{
    public class MerchantReposatry: GenericRepository<MerchantAccount>
    {
        private readonly ShippingDBContext context;
        public MerchantReposatry(ShippingDBContext context) : base(context)
        {
            this.context = context;
        }

        //private method to get all navigation properties I need
        private async Task< IQueryable<MerchantAccount>> GetMerchants(Expression<Func<MerchantAccount, bool>> expression)
        {
            //Note => you must handle this function, when there is no data for orders in database it occures error (nullReference error)
           var m = context.MerchantAccounts.Include(merchant => merchant.Branch)
                                 .Include(merchant => merchant.SpecialOffer)
                                 //.Include(merchant => merchant.Government)
                                 //.Include(merchant => merchant.Orders)
                                 //.Include(merchant => merchant.Role)
                                 .Where(expression)
                                 .AsNoTracking();
            return  m;
        }
        //private method to get all navigation properties I need
        public async Task< MerchantAccount> GetSpecificMerchantWithNavigation(int id)
        {
            var m = GetMerchants(m => m.Id == id).Result.FirstOrDefaultAsync();
            return  await m;
        }
    }
}
