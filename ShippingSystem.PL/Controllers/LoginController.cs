using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.LoginDTOs;
using ShippingSysem.BLL.Services;
using ShippingSystem.DAL.Models;
namespace ShippingSystem.PL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		
		public readonly LoginService LoginService;
        public LoginController(LoginService loginService)
        {
			LoginService = loginService;
		}

		[HttpPost("Employee")]
		public async Task<IActionResult> LoginEmployee(CreateLoginDTO createLoginDTO)
		{
			//var login = LoginService.Login(email, password);

			return  Ok(await LoginService.getTokenEmployee(createLoginDTO));
		}
		[HttpPost("Merchant")]
		public async Task<IActionResult> LoginMerchant(string email, string password)
		{
			//var login = LoginService.Login(email, password);
			return Ok();
		}
		[HttpPost("Delivery")]
		public async Task<IActionResult> LoginDelivery(string email, string password)
		{
			//var login = LoginService.Login(email, password);
			return Ok();
		}
	}
}
