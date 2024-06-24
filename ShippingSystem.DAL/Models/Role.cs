using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class Role : IdentityRole<int>
    {


        public virtual List<Account>? Accounts { get; set; } = new List<Account>();
    }
}
