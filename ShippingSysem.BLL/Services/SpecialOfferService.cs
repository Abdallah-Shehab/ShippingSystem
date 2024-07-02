﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingSystem.BLL.DTOs.SpecialOfferDTOS;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Repositories.Base;

namespace ShippingSystem.BLL.Services
{
    public class SpecialOfferService
    {
        private readonly GenericRepository<SpecialOffer> _specialOfferRepository;

        public SpecialOfferService(GenericRepository<SpecialOffer> specialOfferRepository)
        {
            _specialOfferRepository = specialOfferRepository;
        }

        public async Task<SpecialOffer> GetSpecialOfferByIdAsync(int id)
        {
            return await _specialOfferRepository.GetByIdAsync(id);
        }

        public async Task<IList<SpecialOffer>> GetAllSpecialOffersAsync()
        {
            var specialOffers = await _specialOfferRepository.GetAllAsync();
            return specialOffers.ToList();
        }

        public async Task<SpecialOffer> AddSpecialOfferAsync(AddSpecialOfferDTO specialOfferDTO)
        {
            var specialOffer = new SpecialOffer
            {
                Government = specialOfferDTO.Government,
                City = specialOfferDTO.City,
                DeliveryPrice = specialOfferDTO.DeliveryPrice,
                MerchantId = specialOfferDTO.MerchantId
            };

            var result = await _specialOfferRepository.AddAsync(specialOffer);
            await _specialOfferRepository.SaveAsync(); 
            return result;
        }



    }
}
