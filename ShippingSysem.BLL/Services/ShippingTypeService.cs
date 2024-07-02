using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class ShippingTypeService
    {
        private readonly IGenericRepository<ShippingType> shippingTypeReposatry;

        public ShippingTypeService(IGenericRepository<ShippingType> shippingTypeReposatry)
        {
            this.shippingTypeReposatry = shippingTypeReposatry;
        }

        public async Task<IQueryable<ShippingTypeReadDTO>> getAllTypes() { 
          IQueryable<ShippingType> shippingTypes= shippingTypeReposatry.GetAllAsync().Result;
          return  shippingTypes.Select(x => new ShippingTypeReadDTO
          {
              Id = x.Id,
              Name = x.Name,
          });
        }

        public async Task<decimal> getPriceOfShippingType(int id) {
            ShippingType shipping =await shippingTypeReposatry.GetByIdAsync(id);
            return  shipping.Price;
        }
    }
}
