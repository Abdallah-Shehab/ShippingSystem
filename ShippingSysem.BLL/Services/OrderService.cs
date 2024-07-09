﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using ShippingSysem.BLL.DTOs.OrderDTOs;
using ShippingSysem.BLL.DTOs.ProductDTOs;
using ShippingSystem.BLL.Services;
using ShippingSystem.DAL.Interfaces;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories;
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
        private readonly MerchantReposatry merchantReposatry;

        public DeliveryTpeService DeliveryTpeService { get; }

        public OrderService(
            IOrderRepository repository,
            MerchantAccountService merchantService,
            DeliveryTpeService deliveryTpeService,
            ShippingTypeService shippingTypeService,
            IGenericRepository<DeliveryType> deliveryReposatry,
            IGenericRepository<City> cityReposatry,
            SpecialOfferService specialOfferService,
            MerchantReposatry merchantReposatry
            )
        {
            this.repository = repository;
            this.merchantService = merchantService;
            DeliveryTpeService = deliveryTpeService;
            this.shippingTypeService = shippingTypeService;
            this.deliveryReposatry = deliveryReposatry;
            this.cityReposatry = cityReposatry;
            this.specialOfferService = specialOfferService;
            this.merchantReposatry = merchantReposatry;
        }

        //Mpping The Orders return from The Database without Pagination and using Status as filteration
        public async Task<List<OrederReadDTO>> GetAllFilterdOrders(string status = "")
        {
            var orders = await repository.GetAllFilterdOrdersAsync(status);

            return await MappingorderDTOs(orders);
        }

        //Mapping the orders return from database using status as filteration
        public async Task<List<OrederReadDTO>> GetAllOrdersForMerchant(string status, int merchantId)
        {
            var orders = await repository.GetAllOrdersForMerchant(status, merchantId);

            return await MappingorderDTOs(orders);
        }

        //Mapping the orders return from database using status as filteration
        public async Task<List<OrederReadDTO>> GetAllOrdersForDelivery(string status, int deliveryId)
        {
            var orders = await repository.GetAllOrdersForDelivery(status, deliveryId);

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

        public async Task<bool> UpdateOrderStatus(int id, string status)
        {
            var order = await repository.GetByIdAsync(id);
            if (order != null)
            {
                order.Status = status;
                await repository.SaveAsync();
                return true;
            }
            return false;
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
                StaffMemberName = o.StaffMemberAccount.Name ?? "",
                MerchantName = o.MerchantAccount.Name ?? "",
                DeliveryName = o.DeliveryAccount.Name ?? "",
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
            //City Order
            City city = orderWithNavigationProperties.city;
            //Merchant Create Order
            MerchantAccount merchant = await merchantService.getMerchantAccountWithNavigationProperites(orderWithNavigationProperties.MerchantID);


            //Prices
            decimal cityPrice;
            decimal ShippingTypePrice;
            decimal IncreaseIFweightMoreThan10 = 0;
            decimal priceProducts = order.TotalPrice;
            decimal ifvillage=0;


            //1-get  shippingType Price
            ShippingTypePrice = await shippingTypeService.getPriceOfShippingType(_orderCreateDto.ShippingTypeID);

            //2- count if weight of products increase than the normal wait 
            if (order.TotalWeight > 10)
            {

                IncreaseIFweightMoreThan10 = (order.TotalWeight - 10) * 5;
            }

            //3- get Price is Village
            if (order.StreetAndVillage!="") {
                ifvillage = 30; //constant Price 
            }
            
            
            
            
            
            //--------------------------------Delivery From Branch To Client ---------------------------------------//
            //search on special Offers for this merchant if have special Package  for this merchant 
            var ifMerchantHasSpecialOffer = merchant.SpecialOffer.Where(s => s.City.ToLower() == city.Name.ToLower()).FirstOrDefault();
            if (ifMerchantHasSpecialOffer != null)
            {
                //حساب سعر المدينة من التاجر 
                cityPrice = ifMerchantHasSpecialOffer.DeliveryPrice;
            }
            else
            {
                //حساب سعر المدينة العادي 
                cityPrice = city.NormalShippingCost;
            }
            //--------------------------------------------------------------------//




            //-------------------------------- Delivery From Merchant To Branch ---------------------------------------//
            if (orderWithNavigationProperties.deliveryType.Name == "التسليم من التاجر") {
                
                // اذا التاجر له سعر pickaup  خاص به 
                var ifMerchantHasPcikaup = merchant.Pickup_Price;
                if (ifMerchantHasPcikaup != 0)
                {
                    //Take Pickaup From Merchant
                    cityPrice += ifMerchantHasPcikaup;
                }
                else {
                    //Take Pickaup From City 
                    cityPrice += city.PickupShippingCost;
                }
            }


           //------------------------------------------------------------------------//
           
            
            
          
           

            

            // save delivery price and recived price



          order.DeliveryPrice = cityPrice + ShippingTypePrice + IncreaseIFweightMoreThan10 + ifvillage;
            order.PaiedMoney = order.DeliveryPrice + order.TotalPrice;
            
            repository.Update(order);
            return new OrederReadDTO()
            {
                TotalWeight = order.TotalWeight,
                TotalPrice = order.TotalPrice,
               DeliveryPrice = order.DeliveryPrice,
                StreetAndVillage = order.StreetAndVillage,
                ClientName = order.ClientName,
                CreatedDate = order.CreatedDate,
                MerchantName = orderWithNavigationProperties.MerchantAccount.Name,
                Status = "Created",
                Cityt = orderWithNavigationProperties.city.Name,
                Notes = order.Notes,
                PaiedMoney = order.PaiedMoney,

            };


        }


    }
}
