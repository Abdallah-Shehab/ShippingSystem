using ShippingSystem.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class Branch: IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        
        [Required]
        public bool Status { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Government")]
        public int? GovernmentID { get; set; }

        public Government Government { get; set; }

        public virtual List<Account>? Accounts { get; set; } = new List<Account>();

    }
}
