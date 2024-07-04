using ShippingSysem.BLL.DTOs.ProductDTOs;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.OrderDTOs
{
    public class OrderCreateDTO
    {
        public string ClientName { get; set; }//1
        public string Status { get; set; } = "Created";//2
        public decimal TotalPrice { get; set; }//3
        public decimal TotalWeight { get; set; }//4
        public  string PhoneOne { get; set; }//5
        public  string PhoneTwo { get; set; }//6
        public  string Email { get; set; }//7
        public  string Notes { get; set; }//8
        public  string StreetAndVillage { get; set; }//9
        public  bool IfVillage { get; set; }
        public  int CityID { get; set; }//10
        public  int MerchantID { get; set; }//11
        public  int ShippingTypeID { get; set; }//12
        public  int DeliveryTypeID { get; set; }//13
        public  int PaymentTypeID { get; set; }//14
        public  int GovernmentId { get; set; }//15
        public  List<ProductCreateDTO> Products { get; set; }//16
    }
}
