
using Microsoft.AspNetCore.Identity;
using ShippingSysem.BLL.DTOs.Create;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.PL.DTOs.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class EmployeeService
    {
        private readonly IGenericRepository<Account> genRepo;
        private readonly UserManager<Account> userManager;

        public EmployeeService(IGenericRepository<Account> genRepo, UserManager<Account> userManager)
        {
            this.genRepo = genRepo;
            this.userManager = userManager;
        }



        public async Task<Account> AddEmp(CreateEmployeeDTO EmpDto)
        {
            Account acc = new Account()
            {
                UserName = EmpDto.email,
                Name = EmpDto.name,
                PhoneNumber = EmpDto.phone,
                Address = EmpDto.address,
                BranchID = EmpDto.BranchId,
                RoleID = EmpDto.RoleId,
                Email = EmpDto.email,
                Status = EmpDto.Status

            };
            var result = await userManager.CreateAsync(acc, EmpDto.password);
            if (result.Succeeded)
            {

                return acc;
            }
            else
            {
                // Handle errors (e.g., log them or throw an exception)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task<List<ReadEmployeeDTO>> GetAll()
        {
            var accounts = await genRepo.GetAllAsync();
            var dtos = accounts
                .Select(acc =>
                new ReadEmployeeDTO
                {
                    id = acc.Id,
                    name = acc.Name,
                    BranchName = acc.Branch.Name,
                    email = acc.Email,
                    phone = acc.PhoneNumber
                }).ToList();

            return dtos;
        }
    }
}
