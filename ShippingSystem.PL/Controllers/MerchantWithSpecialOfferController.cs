using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs.MerchantDTOS;
using ShippingSystem.DAL.Models;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantWithSpecialOfferController : ControllerBase
    {
        private readonly ShippingDBContext _context;

        public MerchantWithSpecialOfferController(ShippingDBContext context)
        {
            _context = context;
        }

        [HttpPost("addMerchantWithSpecialOffers")]
        public async Task<IActionResult> AddMerchantWithSpecialOffers([FromBody] AddMerchantWithSpecialOffersDTO data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var merchant = new MerchantAccount
            {
                UserName = data.Merchant.Email,
                Email = data.Merchant.Email,
                Name = data.Merchant.Name,
                Address = data.Merchant.Address,
                PhoneNumber = data.Merchant.Phone,
                BranchID = data.Merchant.BranchId,
                City = data.Merchant.City,
                Government = data.Merchant.Government,
                StoreName = data.Merchant.StoreName,
                Refund_Percentage = data.Merchant.Refund_Percentage,
                Pickup_Price = data.Merchant.Pickup_Price,
                Status = true 
            };

           

            _context.MerchantAccounts.Add(merchant);
            await _context.SaveChangesAsync();

            foreach (var offer in data.SpecialOffers)
            {
                var specialOffer = new SpecialOffer
                {
                    City = offer.City,
                    Government = offer.Government,
                    DeliveryPrice = offer.DeliveryPrice,
                    MerchantId = merchant.Id
                };
                _context.SpecialOffer.Add(specialOffer);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }



        [HttpGet("getMerchantWithSpecialOffers/{merchantId}")]
        public async Task<IActionResult> GetMerchantWithSpecialOffersById(int merchantId)
        {
            var merchant = await _context.MerchantAccounts
                .Include(m => m.SpecialOffer)
                .FirstOrDefaultAsync(m => m.Id == merchantId);

            if (merchant == null)
            {
                return NotFound();
            }

            var merchantWithSpecialOffersDTO = new GetMerchantWithSpecialOffersDTO
            {
                Merchant = new MerchantDTO
                {
                    //ID = merchant.Id,
                    Email = merchant.Email,
                    Name = merchant.Name,
                    Address = merchant.Address,
                    Phone = merchant.PhoneNumber,
                    BranchId = merchant?.BranchID ?? 0,
                    City = merchant.City,
                    Government = merchant.Government,
                    StoreName = merchant.StoreName,
                    Refund_Percentage = merchant.Refund_Percentage,
                    Pickup_Price = merchant.Pickup_Price
                },
                SpecialOffers = merchant.SpecialOffer.Select(offer => new SpecialOfferDTO
                {
                    Id = offer.Id,
                    City = offer.City,
                    Government = offer.Government,
                    DeliveryPrice = offer.DeliveryPrice
                }).ToList()
            };

            return Ok(merchantWithSpecialOffersDTO);
        }





        [HttpPut("updateMerchantWithSpecialOffers/{merchantId}")]
        public async Task<IActionResult> UpdateMerchantWithSpecialOffers(int merchantId, [FromBody] UpdateMerchantWithSpecialOffersDTO data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var merchant = await _context.MerchantAccounts
                .Include(m => m.SpecialOffer)
                .FirstOrDefaultAsync(m => m.Id == merchantId);

            if (merchant == null)
            {
                return NotFound();
            }

            // Update merchant details
            merchant.Email = data.Merchant.Email;
            merchant.Name = data.Merchant.Name;
            merchant.Address = data.Merchant.Address;
            merchant.PhoneNumber = data.Merchant.Phone;
            merchant.BranchID = data.Merchant.BranchId;
            merchant.City = data.Merchant.City;
            merchant.Government = data.Merchant.Government;
            merchant.StoreName = data.Merchant.StoreName;
            merchant.Refund_Percentage = data.Merchant.Refund_Percentage;
            merchant.Pickup_Price = data.Merchant.Pickup_Price;

            // Remove old special offers
            _context.SpecialOffer.RemoveRange(merchant.SpecialOffer);

            // Add new special offers
            foreach (var offer in data.SpecialOffers)
            {
                var specialOffer = new SpecialOffer
                {
                    City = offer.City,
                    Government = offer.Government,
                    DeliveryPrice = offer.DeliveryPrice,
                    MerchantId = merchant.Id
                };
                _context.SpecialOffer.Add(specialOffer);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
