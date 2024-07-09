using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.MerchantDTOS
{
    public class AddMerchantWithSpecialOffersDTO
    {

        public MerchantDTO Merchant { get; set; }
        public List<SpecialOfferDTO> SpecialOffers { get; set; }
    }



    public class MerchantDTO
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int BranchId { get; set; }
        public string City { get; set; }
        public string Government { get; set; }
        public string StoreName { get; set; }
        public decimal Refund_Percentage { get; set; }
        public decimal Pickup_Price { get; set; }
    }

    public class SpecialOfferDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Government { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
