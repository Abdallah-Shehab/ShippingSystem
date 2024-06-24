using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class Government
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }

        [ForeignKey("Branch")]
        public int? BranchID { get; set; }

        public Branch Branch { get; set; }

        public virtual List<City>? Cities { get; set; } = new List<City>();

    }
}
