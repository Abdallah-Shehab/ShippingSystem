using ShippingSysem.BLL.DTOs;
using ShippingSysem.BLL.DTOs.PaymentTypeDTO;
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
    public class PaymentTypeService
    {
        private readonly IGenericRepository<PaymentType> paymentTypeReposatry;

        public PaymentTypeService(IGenericRepository<PaymentType> paymentTypeReposatry)
        {
            this.paymentTypeReposatry = paymentTypeReposatry;
        }

        public async Task<IQueryable<PaymentTypeReadDTO>> getAllTypes()
        {
            IQueryable<PaymentType> shippingTypes = paymentTypeReposatry.GetAllAsync().Result;
            return shippingTypes.Select(x => new PaymentTypeReadDTO
            {
                Id = x.Id,
                Name = x.Name,
            });
        }
        
    }
}
