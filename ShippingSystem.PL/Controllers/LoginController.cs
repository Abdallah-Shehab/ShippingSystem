using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.LoginDTOs;
using ShippingSysem.BLL.Services;
using ShippingSysem.BLL.Services.Base;
using ShippingSystem.DAL.Models;
using ShippingSystem.DAL.Models.Base;
namespace ShippingSystem.PL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase 
	{
		
		public readonly GenericLoginService<Account> accountLoginService;
		public readonly GenericLoginService<MerchantAccount> merchantLoginService;
		public readonly GenericLoginService<DeliveryAccount> deliveryLoginService;
		public LoginController(GenericLoginService<Account> accountLoginService,
								GenericLoginService<MerchantAccount> merchantLoginService,
								GenericLoginService<DeliveryAccount> deliveryLoginService)
		{
			this.accountLoginService = accountLoginService;
			this.merchantLoginService = merchantLoginService;
			this.deliveryLoginService = deliveryLoginService;
		}

		[HttpPost("Employee")]
		public async Task<IActionResult> LoginEmployee(CreateLoginDTO createLoginDTO)
		{
			return  Ok(await accountLoginService.getTokenEmployee(createLoginDTO, account => account.Role));
		}


		[HttpPost("Merchant")]
		public async Task<IActionResult> LoginMerchant(CreateLoginDTO createLoginDTO)
		{
			return Ok(await merchantLoginService.getTokenEmployee(createLoginDTO, account => account.Role));
		}



		[HttpPost("Delivery")]
		public async Task<IActionResult> LoginDelivery(CreateLoginDTO createLoginDTO)
		{
			return Ok(await deliveryLoginService.getTokenEmployee(createLoginDTO, account => account.Role));
		}
	}
}
