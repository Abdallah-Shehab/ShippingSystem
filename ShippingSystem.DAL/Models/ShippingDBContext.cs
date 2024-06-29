﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.DAL.Models
{
    public class ShippingDBContext : IdentityDbContext<Account, Role, int>
    {
        public DbSet<Account> Accounts;
        public DbSet<Role> Roles;
        public DbSet<Permission> Permissions;
        public DbSet<ExistedEntities> Entities;
        //public DbSet<AccountPermissions> Permissions_Users_Entities;
        public DbSet<Branch> Branches;
        public DbSet<City> Cities;
        public DbSet<Government> Governments;
        public DbSet<Order> Orders;
        public DbSet<Product> Products;
        public DbSet<PaymentType> PaymentTypes;
        public DbSet<ShippingType> ShippingTypes;
        public DbSet<MerchantAccount> MerchantAccounts;
        public DbSet<DeliveryAccount> DeliveryAccounts;

        public ShippingDBContext(DbContextOptions<ShippingDBContext> options) : base(options)
        {
        }

        public ShippingDBContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {




            builder.Entity<Account>()
            .ToTable("Accounts");

            builder.Entity<DeliveryAccount>()
                .ToTable("DeliveryAccounts");

            builder.Entity<MerchantAccount>()
                .ToTable("MerchantAccounts");


            //add data 


            builder.Entity<PaymentType>(entity => entity.HasData(
                new PaymentType { Id = 1, Name = "Cash" },
                new PaymentType { Id = 2, Name = "Visa" }

                ));

            builder.Entity<ShippingType>(entity => entity.HasData(
              new ShippingType { Id = 1, Name = "Normal", Price = 30 },
              new ShippingType { Id = 2, Name = "7 Days", Price = 50 },
              new ShippingType { Id = 3, Name = "24 Hour", Price = 70 }


              ));

            builder.Entity<Role>(entity => entity.HasData(
              new Role { Id = 1, Name = "Merchant" },
              new Role { Id = 2, Name = "Employee" },
              new Role { Id = 3, Name = "Delivery" },
              new Role { Id = 4, Name = "Admin" }
              ));

            builder.Entity<ExistedEntities>(entity => entity.HasData(
            new ExistedEntities { Id = 1, Name = "Settings" },
            new ExistedEntities { Id = 2, Name = "Branches" },
            new ExistedEntities { Id = 3, Name = "Employees" },
            new ExistedEntities { Id = 4, Name = "Merchants" },
            new ExistedEntities { Id = 5, Name = "Deliveries" },
            new ExistedEntities { Id = 6, Name = "Governorates" },
            new ExistedEntities { Id = 7, Name = "Cities" },
            new ExistedEntities { Id = 8, Name = "Orders" },
            new ExistedEntities { Id = 9, Name = "Financials" },
            new ExistedEntities { Id = 10, Name = "Reports" }
             ));
            // Seed initial account
            var hasher = new PasswordHasher<Account>();
            var newAccount = new Account
            {
                Id = 1,
                UserName = "newuser",
                Email = "newuser@example.com",
                Name = "New User",
                Address = "123 New Street",
                Status = true,
                PasswordHash = hasher.HashPassword(null, "password") // Set a default password
            };

            builder.Entity<Account>().HasData(newAccount);

            // Seed permissions for the new account
            builder.Entity<Permission>().HasData(
                new Permission
                {
                    Id = 1,
                    AccountId = newAccount.Id,
                    EntityId = 1, // Settings
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                },
                new Permission
                {
                    Id = 2,
                    AccountId = newAccount.Id,
                    EntityId = 2, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 3,
                    AccountId = newAccount.Id,
                    EntityId = 3, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 4,
                    AccountId = newAccount.Id,
                    EntityId = 4, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 5,
                    AccountId = newAccount.Id,
                    EntityId = 5, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 6,
                    AccountId = newAccount.Id,
                    EntityId = 6, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 7,
                    AccountId = newAccount.Id,
                    EntityId = 7, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 8,
                    AccountId = newAccount.Id,
                    EntityId = 8, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 9,
                    AccountId = newAccount.Id,
                    EntityId = 9, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }, new Permission
                {
                    Id = 10,
                    AccountId = newAccount.Id,
                    EntityId = 10, // Branches
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                    CanCreate = false
                }


            );
            base.OnModelCreating(builder);
        }
    }
}
