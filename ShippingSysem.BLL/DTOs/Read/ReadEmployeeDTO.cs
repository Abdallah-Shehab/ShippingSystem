﻿namespace ShippingSystem.PL.DTOs.Read
{
    public class ReadEmployeeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public string phone { get; set; }

        public string BranchName { get; set; }
        public string RoleName { get; set; }

        public bool Status { get; set; }
    }
}
