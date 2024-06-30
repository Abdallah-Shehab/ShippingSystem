﻿using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.Services;
using ShippingSysem.BLL.DTOs.DeliveryDTOS; 

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase 
    {
        private readonly DeliveryAccountService deliveryAccountService;

        public DeliveryController(DeliveryAccountService deliveryAccountService)
        {
            this.deliveryAccountService = deliveryAccountService;
        }

        //Action to display Delivery Accounts
        [HttpGet]
        public async Task<IActionResult> GetAllDeliveryAccounts()
        {
            var accounts = await deliveryAccountService.GetAllDeliveryAccounts();
            return Ok(accounts);
        }


        //Action to Add delivery Account
        [HttpPost]
        public async Task<IActionResult> AddDeliveryAccount([FromBody] AddDeliveryAccountDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await deliveryAccountService.AddDeliveryAccount(dto);
            if (success)
            {
                return Ok("Delivery account added successfully.");
            }

            return BadRequest("Could not add delivery account.");
        }



        // Action to Delete Delivery Account
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryAccount(int id)
        {
            var success = await deliveryAccountService.DeleteDeliveryAccount(id);
            if (success)
            {
                return Ok($"Delivery account with ID {id} deleted successfully.");
            }

            return BadRequest($"Could not delete delivery account with ID {id}.");
        }




        // Action to Get Delivery Account by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryAccountById(int id)
        {
            var account = await deliveryAccountService.GetDeliveryAccountById(id);
            if (account == null)
            {
                return NotFound($"Delivery account with ID {id} not found.");
            }

            return Ok(account);
        }



        // Action to Update Delivery Account
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeliveryAccount(int id, [FromBody] AddDeliveryAccountDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await deliveryAccountService.UpdateDeliveryAccount(id, dto);
            if (success)
            {
                return Ok($"Delivery account with ID {id} updated successfully.");
            }

            return NotFound($"Delivery account with ID {id} not found or update failed.");
        }

    }
}
