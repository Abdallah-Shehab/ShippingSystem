using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.LoginDTOs
{
    public class MessageOrToken
    {
        public string? Msg { get; set; }
        public ReadLoginDTO? ReadLoginDTO { get; set; }=new ReadLoginDTO();
    }
}
