﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using ShippingSysem.BLL.DTOs.DeliveryDTOS;
using ShippingSysem.BLL.DTOs.MerchantDTOS;
using ShippingSystem.DAL.Interfaces.Base;
using ShippingSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSysem.BLL.Services
{
    public class MerchantAccountService
    {
        private readonly IGenericRepository<MerchantAccount> genRepo;
        private readonly IPasswordHasher<MerchantAccount> passwordHasher;

        public MerchantAccountService(
            IGenericRepository<MerchantAccount> genRepo,
            IPasswordHasher<MerchantAccount> passwordHasher
            )
        {
            this.genRepo = genRepo;
            this.passwordHasher = passwordHasher;
        }




        //method to Display All Merchant Accounts
        public async Task<List<DisplayMerchantAccountsDTO>> GetAllMerchantAccounts()
        {
            var accounts = await genRepo.GetAllAsync();
            var dtos = accounts
                .Select(acc => new DisplayMerchantAccountsDTO
                {

                    ID = acc.Id,
                    Phone = acc.PhoneNumber,
                    Name = acc.Name,
                    email = acc.Email,

                    password = acc.PasswordHash,
                    Branch = acc.Branch.Name,
                    Address = acc.Address,
                    StoreName = acc.StoreName,
                    Government = acc.Government,
                    City = acc.City,
                    Pickup_Price = acc.Pickup_Price,
                    Refund_Percentage = acc.Id,


                })
                .ToList();

            return dtos;
        }




        //method to Add Merchant Account
        public async Task<bool> AddMerchantAccount(AddMerchantAccountDTO dto)
        {
            try
            {
                var account = new MerchantAccount
                {
                    PhoneNumber = dto.Phone,
                    Name = dto.Name,
                    NormalizedUserName = dto.Name.ToUpper(),
                    Email = dto.Email,
                    NormalizedEmail = dto.Email.ToUpper(),
                    EmailConfirmed = true,
                    BranchID = dto.BranchId,
                    Address = dto.Address,
                    StoreName = dto.StoreName,
                    Government = dto.Government,
                    City = dto.City,
                    Pickup_Price = dto.Pickup_Price,
                    Refund_Percentage = dto.Refund_Percentage,
                    UserName = dto.Name,
                    RoleID = 3
                };

                // Hash the password
                account.PasswordHash = passwordHasher.HashPassword(account, dto.Password);
                await genRepo.AddAsync(account);
                await genRepo.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        // Method to delete merchant account
        public async Task<bool> DeleteMerchantAccount(int accountId)
        {
            try
            {
                var account = await genRepo.GetByIdAsync(accountId);
                if (account == null)
                {
                    return false;
                }

                await genRepo.DeleteById(accountId);
                await genRepo.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        // Method to get merchant account by ID
        public async Task<MerchantAccount> GetMerchantAccountById(int id)
        {
            return await genRepo.GetByIdAsync(id);
        }





        // Method to update merchant account
        public async Task<bool> UpdateMerchantAccount(int accountId, AddMerchantAccountDTO dto)
        {
            try
            {
                var existingAccount = await genRepo.GetByIdAsync(accountId);
                if (existingAccount == null)
                {
                    return false;
                }

                // Update properties
                existingAccount.Name = dto.Name;
                existingAccount.PhoneNumber = dto.Phone;
                existingAccount.Email = dto.Email;
                existingAccount.PasswordHash = dto.Password;
                existingAccount.BranchID = dto.BranchId;
                existingAccount.Address = dto.Address;
                existingAccount.StoreName = dto.StoreName;
                existingAccount.Government = dto.Government;
                existingAccount.City = dto.City;
                existingAccount.Pickup_Price = dto.Pickup_Price;
                existingAccount.Refund_Percentage = dto.Refund_Percentage;
                existingAccount.UserName = dto.Name;

                await genRepo.Update(existingAccount);
                await genRepo.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //==========================
        // Method to get if Merchant have Special Package Or Not
        public async Task<bool> ifMerchantHavePackage(int id)
        {
            MerchantAccount merchant = await genRepo.GetByIdAsync(id);
            if (merchant.SpecialOffer == null)
            {

                return false;
            }
            else
            {
                return true;
            }

        }

        public async Task<decimal> getRefoundToMerchant(int id)
        {
            MerchantAccount merchant = await genRepo.GetByIdAsync(id);
            return merchant.Refund_Percentage;
        }

    }
}
