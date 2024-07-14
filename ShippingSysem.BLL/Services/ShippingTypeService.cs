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
        private readonly IGenericRepository<City> cityReposatry;

        public ShippingTypeService(
            IGenericRepository<ShippingType> shippingTypeReposatry,
            IGenericRepository<City> cityReposatry)
        {
            this.shippingTypeReposatry = shippingTypeReposatry;
            this.cityReposatry = cityReposatry;
        }

        public async Task<IQueryable<ShippingTypeReadDTO>> getAllTypes()
        {
            IQueryable<ShippingType> shippingTypes = shippingTypeReposatry.GetAllAsync().Result;
            return shippingTypes.Select(x => new ShippingTypeReadDTO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            });
        }

        // get price for shipping type and price for city
        public async Task<decimal> getPriceOfShippingType(int idShipping)
        {
            ShippingType shipping = await shippingTypeReposatry.GetByIdAsync(idShipping);
            return shipping.Price;
        }
    }
}
