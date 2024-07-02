using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingTypeController : ControllerBase
    {
        private readonly ShippingTypeService shippingService;

        public ShippingTypeController(ShippingTypeService shippingService)
        {
            this.shippingService = shippingService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll() {
            return Ok(await shippingService.getAllTypes());
        }
    }
}
