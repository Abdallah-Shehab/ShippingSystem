using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class MerchantAccount : Account
    {
        [ForeignKey("account")]
        public int Account_id { get; set; }
        public Account account { get; set; }
        [Required]
        public string StoreName { get; set; }

        [Required]
        public string Government { get; set; }
        [Required]
        public string City { get; set; }
        public decimal Pickup_Price { get; set; }
        [Required]
        public decimal Refund_Percentage { get; set; }


    }
}
