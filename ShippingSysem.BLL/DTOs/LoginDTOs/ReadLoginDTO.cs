using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.LoginDTOs
{
	public class ReadLoginDTO
	{
		public string token {  get; set; }
		public string Role { get; set; }
		public string Name { get; set; }
		public int id { get; set; }
	}
}
