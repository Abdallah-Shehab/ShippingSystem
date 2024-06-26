using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class DeliveryAccount : IdentityUser<int>
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        [Required]
        public string Address { get; set; }
        [Required]
        public bool Status { get; set; }

        [ForeignKey("Role")]
        public int? RoleID { get; set; }

        public Role Role { get; set; }

        [ForeignKey("Branch")]
        public int? BranchID { get; set; }

        public Branch Branch { get; set; }

        public virtual List<Order>? Orders { get; set; } = new List<Order>();


        public decimal Discount_type { get; set; }
        public decimal Company_Percantage { get; set; }



    }
}
