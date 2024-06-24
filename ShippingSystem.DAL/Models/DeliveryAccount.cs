using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class DeliveryAccount : Account
    {
        [ForeignKey("account")]
        public int Account_id { get; set; }
        public Account account { get; set; }

        public decimal Discount_type { get; set; }
        public decimal Company_Percantage { get; set; }



    }
}
