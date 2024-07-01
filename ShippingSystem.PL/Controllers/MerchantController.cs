using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {

        private readonly MerchantAccountService _merchantAccountService;

        public MerchantController(MerchantAccountService _merchantAccountService)
        {
            this._merchantAccountService = _merchantAccountService;
        }


        //Action to display Merchant Accounts
        [HttpGet]
        public async Task<IActionResult> GetAllMerchantAccounts()
        {
            var accounts = await _merchantAccountService.GetAllMerchantAccounts();
            return Ok(accounts);
        }


    }
}
