using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    //public enum StatusOptions
    //{
    //    Pending,
    //    Approved,
    //    Rejected
    //}
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string ClientName { get; set; }


        [Required]
        //[EnumDataType(typeof(StatusOptions))]
        public string Status { get; set; }


        [Required]
        public Decimal TotalPrice { get; set; }

        [Required]
        public Decimal TotalWeight { get; set; }


        [Required]
        public string PhoneOne { get; set; }

        public string? PhoneTwo { get; set; }


        public string? Email { get; set; }

        public string? Notes { get; set; }
        [Required]
        public string StreetAndVillage { get; set; }

        [ForeignKey("StaffMemberAccount")]
        public int? StaffMemberID { get; set; }

        [ForeignKey("MerchantAccount")]
        public int? MerchantID { get; set; }
        [ForeignKey("DeliveryAccount")]
        public int? DeliveryID { get; set; }

        [ForeignKey("ShippingType")]
        public int? ShippingTypeID { get; set; }
        [ForeignKey("paymentType")]
        public int? PaymentTypeID { get; set; }

        public Account StaffMemberAccount { get; set; }
        public MerchantAccount MerchantAccount { get; set; }
        public DeliveryAccount DeliveryAccount { get; set; }

        public ShippingType ShippingType { get; set; }
        public PaymentType paymentType { get; set; }
        public virtual List<Product>? Products { get; set; } = new List<Product>();


    }
}
