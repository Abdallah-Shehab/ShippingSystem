using ShippingSystem.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingSystem.BLL.DTOs.SpecialOfferDTOS
{
    public class AddSpecialOfferDTO
    {
        public string Government { get; set; }
        public string City { get; set; }
        public decimal DeliveryPrice { get; set; }


        public int MerchantId { get; set; }


    }
}
