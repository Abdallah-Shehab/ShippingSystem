using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Repositories.Base
{
    public class GenericLoginReposatry<T> : GenericRepository<T> where T : class, IEntity
    {
        private readonly ShippingDBContext context;
        private readonly DbSet<T> dbSet;
        public GenericLoginReposatry(ShippingDBContext context) : base(context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        //public IQueryable<T> GetAccountsWithAllNavigation(Expression<Func<T, bool>> expression)
        //{
        //	//Note => you must handle this function, when there is no data for orders in database it occures error (nullReference error)
        //	return dbSet.Include(account => account.Branch)
        //						 .Include(account => account.Role)
        //						 .Include(account => account.Orders)
        //						 .Where(expression)
        //						 .AsNoTracking();
        //}
        public IQueryable<T> GetAccountsWithAllNavigation(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            //Note => you must handle this function, when there is no data for orders in database it occures error (nullReference error)
            var query = includes.Aggregate(dbSet.AsQueryable(),
                (current, include) => current.Include(include));

            return query.Where(expression);
        }
        public T GetAccountWithRole(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            //Note => you must handle this function, when there is no data for orders in database it occures error (nullReference error)
            var query = includes.Aggregate(dbSet.AsQueryable(),
                (current, include) => current.Include(include));

            return query.Where(expression).FirstOrDefault();

        }
    }
}
