using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using ShippingSysem.BLL.DTOs.OrderDTOs;
using ShippingSysem.BLL.DTOs.ProductDTOs;
using ShippingSystem.BLL.Services;
using ShippingSystem.DAL.Interfaces;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class OrderService
    {
        private readonly IOrderRepository repository;
        private readonly MerchantAccountService merchantService;
        private readonly ShippingTypeService shippingTypeService;
        private readonly IGenericRepository<DeliveryType> deliveryReposatry;
        private readonly IGenericRepository<City> cityReposatry;
        private readonly SpecialOfferService specialOfferService;

        public DeliveryTpeService DeliveryTpeService { get; }

        public OrderService(
            IOrderRepository repository,
            MerchantAccountService merchantService,
            DeliveryTpeService deliveryTpeService,
            ShippingTypeService shippingTypeService,
            IGenericRepository<DeliveryType> deliveryReposatry,
            IGenericRepository<City> cityReposatry,
            SpecialOfferService specialOfferService
            )
        {
            this.repository = repository;
            this.merchantService = merchantService;
            DeliveryTpeService = deliveryTpeService;
            this.shippingTypeService = shippingTypeService;
            this.deliveryReposatry = deliveryReposatry;
            this.cityReposatry = cityReposatry;
            this.specialOfferService = specialOfferService;
        }

        //Mpping The Orders return from The Database without Pagination and using Status as filteration
        public async Task<List<OrederReadDTO>> GetAllFilterdOrders(string status = "")
        {
            var orders = await repository.GetAllFilterdOrdersAsync(status);

            return await MappingorderDTOs(orders);
        }
        
        //Mapping the orders return from database using status as filteration
        public async Task<List<OrederReadDTO>> GetAllOrdersForMerchant(string status="",int merchantId = 0)
        {
            var orders = await repository.GetAllOrdersForMerchant(status, merchantId);

            return await MappingorderDTOs(orders);
        }

        //Mpping The Orders return from The Database with Pagination and using Status as filteration
        public async Task<List<OrederReadDTO>> GetAllFilterdOrders(int page, int pageSize, string status = "")
        {
            var orders = await repository.GetAllFilterdOrdersAsync(page, pageSize, status);

            return await MappingorderDTOs(orders);
        }

        //Get Count For all orders depending on Status 
        public async Task<List<OrderCount>> GetOrderCountsAsync()
        {
            var Orders = await repository.GetOrderCountsAsync();
            return await Orders.ToListAsync();
        }

        //Get Count For all orders for specific mrechant account depending on Status 
        public async Task<List<OrderCount>> GetOrderCountsAsync(int merchantId)
        {
            var Orders = await repository.GetOrderCountsAsync(merchantId);
            return await Orders.ToListAsync();
        }

        public async Task<OrederReadDTO> DeleteOrder(int id)
        {
            var order = await repository.DeleteById(id);
            if (order != null) return await MappingorderToOrderReadDTO(order);
            return null;
        }

        //Private Method using for Mapping The orders return from database(order Repository)
        private async Task<List<OrederReadDTO>> MappingorderDTOs(IQueryable<Order> orders)
        {
            return await orders.Select(o => new OrederReadDTO
            {
                Id = o.Id,
                IsDeleted = o.IsDeleted,
                ClientName = o.ClientName,
                Status = o.Status,
                TotalPrice = o.TotalPrice,
                TotalWeight = o.TotalWeight,
                ReceivedMoney = o.ReceivedMoney,
                DeliveryPrice = o.DeliveryPrice,
                PaiedMoney = o.PaiedMoney,
                Government = o.government.Name,
                Cityt = o.city.Name,
                PhoneOne = o.PhoneOne,
                PhoneTwo = o.PhoneTwo,
                Email = o.Email,
                Notes = o.Notes,
                StreetAndVillage = o.StreetAndVillage,
                StaffMemberName = o.StaffMemberAccount.Name??"",
                MerchantName = o.MerchantAccount.Name,
                DeliveryName = o.DeliveryAccount.Name,
                CreatedDate = o.CreatedDate,
                DeliverydDate = o.DeliverydDate,
            }).ToListAsync();
        }
        private async Task<OrederReadDTO> MappingorderToOrderReadDTO(Order order)
        {

            return new OrederReadDTO()
            {
                Id = order.Id,
                IsDeleted = order.IsDeleted,
                ClientName = order.ClientName,
                Status = order.Status,
                TotalPrice = order.TotalPrice,
                ReceivedMoney = order.ReceivedMoney,
                DeliveryPrice = order.DeliveryPrice,
                PaiedMoney = order.PaiedMoney,
                Government = order.government?.Name, // Null check
                Cityt = order.city?.Name,            // Null check
                PhoneOne = order.PhoneOne,
                PhoneTwo = order.PhoneTwo,
                Email = order.Email,
                Notes = order.Notes,
                StreetAndVillage = order.StreetAndVillage,
                StaffMemberName = order.StaffMemberAccount?.Name, // Null check
                MerchantName = order.MerchantAccount?.Name,       // Null check
                DeliveryName = order.DeliveryAccount?.Name,       // Null check
                CreatedDate = order.CreatedDate,
                DeliverydDate = order.DeliverydDate,
                TotalWeight = order.TotalWeight
            };
        }

        

     
       

        // Mapping the Orders from Dto To Database 
        public async Task<OrederReadDTO> CreateOrder(OrderCreateDTO _orderCreateDto)
        {

            
            Order order = new Order()
            {
                CitytId = _orderCreateDto.CityID,
                ClientName = _orderCreateDto.ClientName,
                Email = _orderCreateDto.Email,
                Notes = _orderCreateDto.Notes,
                MerchantID = _orderCreateDto.MerchantID,
                PaymentTypeID = _orderCreateDto.PaymentTypeID,
                ShippingTypeID = _orderCreateDto.ShippingTypeID,
                DeliveryTypeID = _orderCreateDto.DeliveryTypeID,
                PhoneOne = _orderCreateDto.PhoneOne,
                PhoneTwo = _orderCreateDto.PhoneTwo,
                Status = "New",
                GovernmentId = _orderCreateDto.GovernmentId,
                StreetAndVillage = _orderCreateDto.StreetAndVillage,
                TotalWeight = _orderCreateDto.TotalWeight,
                TotalPrice = _orderCreateDto.TotalPrice,
                Products = _orderCreateDto.Products.Select(p => new Product()
                {
                    Quantity = p.Quantity,
                    Weight = p.Weight,
                    Price = p.Price,
                    Name = p.Name,

                }).ToList(),
            };
            await repository.AddAsync(order);
            await repository.SaveAsync();
            Order orderWithNavigationProperties = repository.GetAllFilterdOrdersAsync().Result.FirstOrDefault(o => o.Id == order.Id);

            
            //1-get price based ond  shippingType   and price of city
            decimal priceOfShippingType = await shippingTypeService.getPriceOfShippingType( _orderCreateDto.ShippingTypeID,_orderCreateDto.CityID );
            //get Price of DeliveryType
            decimal priceOfDeliveryType = await DeliveryTpeService.getPriceOfShippingType(_orderCreateDto.DeliveryTypeID);

            //2-get precentatge of merchant if has Refound
            decimal refoundOFmerchant = await merchantService.getRefoundToMerchant(_orderCreateDto.MerchantID);


            //4- count if weight of products increase than the normal wait 
            
            decimal IncreaseIFweightMoreThan10=0;
            if (order.TotalWeight > 10) {

                IncreaseIFweightMoreThan10 = (order.TotalWeight - 10) * 5;
            }

            //5- if the merchant have package
            decimal SpecialpakageOfMerchant =30;
            if (await merchantService.ifMerchantHavePackage(order.MerchantID))
            {

                SpecialOffer specialOffer = await specialOfferService.GetSpecialOfferByMerchantIdAsync(order.MerchantID);
                SpecialpakageOfMerchant = specialOffer.DeliveryPrice;
            }

            

            


            // calculate = shippingTypePrice  + DeliveryType + TotalPriceOFProduct -  Refound For the merchant + DeliveryPrice Or SpecialPakage +
            decimal totalPayment = priceOfShippingType  + _orderCreateDto.TotalPrice - refoundOFmerchant + IncreaseIFweightMoreThan10+ SpecialpakageOfMerchant; 
            

            return new OrederReadDTO()
            {
                TotalWeight = order.TotalWeight,
                TotalPrice = order.TotalPrice,
                DeliveryPrice = priceOfDeliveryType + priceOfDeliveryType,
                StreetAndVillage = order.StreetAndVillage,
                ClientName = order.ClientName,
                CreatedDate = order.CreatedDate,
                MerchantName = orderWithNavigationProperties.MerchantAccount.Name,
                Status = "Created",
                Cityt = orderWithNavigationProperties.city.Name,
                Notes = order.Notes,
                PaiedMoney = totalPayment,

            };


        }


    }
}
