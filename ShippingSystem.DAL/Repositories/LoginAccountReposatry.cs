using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces.Base;
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
    public class LoginAccountReposatry:GenericRepository<Account>,IGenericRepository<Account>
    {
        private readonly ShippingDBContext context;
        public  LoginAccountReposatry(ShippingDBContext context):base(context) {
        this.context = context;
      }

        public IQueryable<Account> GetAccountsWithAllNavigation(Expression<Func<Account, bool>> expression)
        {
            //Note => you must handle this function, when there is no data for orders in database it occures error (nullReference error)
            return context.Accounts.Include(account => account.Branch)
                                 .Include(account => account.Role)
                                 .Include(account => account.Orders)
                                 .Where(expression)
                                 .AsNoTracking();
        }
        public Account GetAccountWithRole(Expression<Func<Account, bool>> expression)
        {
            //Note => you must handle this function, when there is no data for orders in database it occures error (nullReference error)
            return context.Accounts.Include(account => account.Role)
                                 .Where(expression).FirstOrDefault();
                                 
        }
    }
}
