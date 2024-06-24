using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class Permission_Role_Entities
    {
        [ForeignKey("role")]
        public int role_id { get; set; }

        [ForeignKey("permission")]
        public int permission_id { get; set; }

        [ForeignKey("entities")]
        public int entity_id { get; set; }

        public Role role { get; set; }
        public Permission permission { get; set; }
        public Entity entity { get; set; }
    }
}
