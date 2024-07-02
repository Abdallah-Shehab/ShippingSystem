using ShippingSysem.BLL.DTOs;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class DeliveryTpeService
    {
        private readonly IGenericRepository<DeliveryType> deliveryTypeReposatyr;

        public DeliveryTpeService(IGenericRepository<DeliveryType> deliveryTypeReposatyr)
        {
            this.deliveryTypeReposatyr = deliveryTypeReposatyr;
        }
        public async Task<IQueryable<ShippingTypeReadDTO>> getAllTypes()
        {
            IQueryable<DeliveryType> deliveryTypes = deliveryTypeReposatyr.GetAllAsync().Result;
            return deliveryTypes.Select(x => new ShippingTypeReadDTO
            {
                Id = x.Id,
                Name = x.Name,
            });
        }
        public async Task<decimal> getPriceOfShippingType(int id)
        {
            DeliveryType delivery = await deliveryTypeReposatyr.GetByIdAsync(id);
            return delivery.Price;
        }
    }
}
