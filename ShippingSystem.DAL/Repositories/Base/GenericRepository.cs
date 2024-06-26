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

        public async Task<T> DeleteById(int id)
        {
            T account = await GetByIdAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            dbSet.Remove(account);

            return account;
        }
        public Task<T> Update(T entity)
        {
            dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(dbSet.Where(obj => obj.IsDeleted == false));
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.FromResult(dbSet.FirstOrDefault(obj => obj.Id == id));
        }

        public Task SaveAsync()
        {
            return Task.FromResult(context.SaveChanges());

        }

        public Task<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
