using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.Services;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryTypeController : ControllerBase
    {
        private readonly DeliveryTpeService DeliveryService;

        public DeliveryTypeController(DeliveryTpeService DeliveryService)
        {
            this.DeliveryService = DeliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await DeliveryService.getAllTypes());
        }
    }
}
