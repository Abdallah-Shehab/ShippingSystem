using Microsoft.EntityFrameworkCore;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly ShippingDBContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(ShippingDBContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public Task<T> AddAsync(T entity)
        {
            dbSet.Add(entity);
            return Task.FromResult(entity);
            //throw new NotImplementedException();
        }

        public Task<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.Where(obj => obj.IsDeleted == false));
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            return Task.FromResult(context.SaveChanges());

        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
