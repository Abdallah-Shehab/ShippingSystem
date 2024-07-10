using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.MerchantDTOS
{
    public class GetMerchantWithSpecialOffersDTO
    {
        public MerchantDTO Merchant { get; set; }
        public List<SpecialOfferDTO> SpecialOffers { get; set; }
    }

    public class UpdateMerchantWithSpecialOffersDTO
    {
        public MerchantDTO Merchant { get; set; }
        public List<SpecialOfferDTO> SpecialOffers { get; set; }
    }

   
    
}
