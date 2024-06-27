using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.OrderDTOs
{
    public class OrederReadDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public decimal TotalWeight { get; set; }
        public string PhoneOne { get; set; } = string.Empty;
        public string PhoneTwo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string StreetAndVillage { get; set; } = string.Empty;
        public string StaffMemberName { get; set; } = string.Empty;
        public string MerchantName { get; set; }    = string.Empty;
        public string DeliveryName { get; set; } = string.Empty;
        
    }
}
