﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.DTOs.BranchDTOs
{
	public class CreateBranchDTO
	{
		public string Name { get; set; }
		public bool Status { get; set; } = true;
		public int GovernmentID { get; set; }
	}
}
