﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShippingSysem.BLL.DTOs.EmployeeDTOS;
using ShippingSysem.BLL.DTOs.EntitiesPermissionsDTOS;
using ShippingSysem.BLL.DTOs.PermissionsDTOS;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class PermissionsService
    {
        private readonly IGenericRepository<Account> genRepo;

        private ShippingDBContext dbContext;


        public PermissionsService(ShippingDBContext dbContext, IGenericRepository<Account> genRepo)
        {

            this.dbContext = dbContext;
            this.genRepo = genRepo;
        }

        //public async Task<List<Permission>> GetAllPermissionsForUser()
        //{
        //    var acc = dbContext.Set<Account>().FirstOrDefault(i=>i.Id==1);
        //    var permissions = acc.Permissions.ToList();

        //    return permissions;
        //}


        public Task<List<PermissionDTO>> GetAllPermissionsForUser(int userId)
        {
            var acc = dbContext.Set<Permission>().Where(i => i.AccountId == userId).Select(a => new PermissionDTO
            {
                EntityId = a.Entity.Id,
                EntityName = a.Entity.Name,
                CanRead = a.CanRead,
                CanWrite = a.CanWrite,
                CanDelete = a.CanDelete,
                CanCreate = a.CanCreate
            }).ToList();


            return Task.FromResult(acc);
        }

    }
}
