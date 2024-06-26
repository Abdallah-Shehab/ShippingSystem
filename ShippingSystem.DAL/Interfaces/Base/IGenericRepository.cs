using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Interfaces.Base
{
    public interface IGenericRepository<T> where T : class,IEntity
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task SaveAsync();
    }
}
