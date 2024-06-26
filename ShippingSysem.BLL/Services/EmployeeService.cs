﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShippingSysem.BLL.DTOs.Create;
using ShippingSysem.BLL.DTOs.EmployeeDTOS;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class EmployeeService
    {
        private readonly IGenericRepository<Account> genRepo;
        private readonly UserManager<Account> userManager;
        private readonly ShippingDBContext dbContext;

        public EmployeeService(IGenericRepository<Account> genRepo, UserManager<Account> userManager, ShippingDBContext dbContext)
        {
            this.genRepo = genRepo;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }



        public async Task<IdentityResult> AddEmp(CreateEmployeeDTO EmpDto)
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

                return result;
            }
            else
            {
                // Handle errors (e.g., log them or throw an exception)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task<List<ReadEmployeeDTO>> GetAllEmps()
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
                    phone = acc.PhoneNumber,
                    Status = acc.Status,
                    RoleName = acc.Role.Name
                }).ToList();

            return dtos;
        }


        public async Task<ReadEmployeeDTO> GetEmpById(int id)
        {
            var acc = await genRepo.GetByIdAsync(id);

            if (acc != null)
            {
                var EmpDTO = new ReadEmployeeDTO()
                {
                    id = acc.Id,
                    name = acc.Name,
                    address = acc.Address,
                    BranchName = acc.Branch?.Name, // Safe navigation operator
                    email = acc.Email,
                    phone = acc.PhoneNumber,
                    RoleName = acc.Role?.Name, // Safe navigation operator
                    Status = acc.Status
                };
                return EmpDTO;
            }
            else
            {

                throw new Exception("Failed To Get Employee Data");
            }


        }


        public async Task<Account> UpdateEmp(int id, CreateEmployeeDTO EmpDto)
        {
            var acc = await genRepo.GetByIdAsync(id);
            if (acc != null)
            {
                acc.Name = EmpDto.name;
                acc.PhoneNumber = EmpDto.phone;
                acc.Address = EmpDto.address;
                acc.BranchID = EmpDto.BranchId;
                acc.RoleID = EmpDto.RoleId;
                acc.Email = EmpDto.email;
                acc.Status = EmpDto.Status;

                await genRepo.SaveAsync();
                return acc;
            }
            else
            {

                throw new Exception("Employee Dosen't Exist");
            }
        }

        public async Task<Account> DeleteEmpByID(int id)
        {
            var acc = await genRepo.DeleteById(id);
            await genRepo.SaveAsync();
            return acc;
        }
    }
}
