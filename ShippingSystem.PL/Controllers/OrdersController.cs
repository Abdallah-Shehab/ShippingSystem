using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingSysem.BLL.DTOs.OrderDTOs;
using ShippingSysem.BLL.Enums;
using ShippingSysem.BLL.Services;
using ShippingSystem.DAL.Models;

namespace ShippingSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService orderService;

        public OrdersController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrederReadDTO>>> GetAll(string status = "")
        {
            var orders = await orderService.GetAllFilterdOrders(status);

            if (!orders.Any())
                return NotFound();

            return Ok(orders);
        }

        [HttpGet("AllWithPagination")]
        public async Task<ActionResult<List<OrederReadDTO>>> GetAllWithPagination(int page = 1, int pageSize = 10, string status = "")
        {
            var orders = await orderService.GetAllFilterdOrders(page, pageSize, status);

            if (!orders.Any())
                return NotFound();

            return Ok(orders);
        }

        [HttpGet("OrdersCount")]
        public async Task<ActionResult<List<OrderCount>>> GetOrdersCount(int merchantId = 0)
        {
            List<OrderCount> orderCounts = new List<OrderCount>();
            if (merchantId == 0) orderCounts = await orderService.GetOrderCountsAsync();
            else orderCounts = await orderService.GetOrderCountsAsync(merchantId);

            //if (!orderCounts.Any())
            //    return NotFound();

            return Ok(orderCounts);
        }

        [HttpGet("AllOrdersForMerchant")]
        public async Task<ActionResult<List<OrederReadDTO>>> GetAllForMerchant(string status = "", int MerchantId = 0)
        {
            var orders = await orderService.GetAllOrdersForMerchant(status, MerchantId);

            //if (!orders.Any())
            //    return NotFound();

            return Ok(orders);
        }

        [HttpGet("AllOrdersForDelivery")]
        public async Task<ActionResult<List<OrederReadDTO>>> GetAllForDelivery(string status = "", int DeliveryId = 0)
        {
            var orders = await orderService.GetAllOrdersForDelivery(status, DeliveryId);

            //if (!orders.Any())
            //    return NotFound();

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderCreateDTO orderCreateDto)
        {
            var order = await orderService.CreateOrder(orderCreateDto);

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await orderService.DeleteOrder(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpGet("OrderStatuses")]
        public ActionResult<IEnumerable<string>> GetOrderStatuses()
        {
            var statuses = Enum.GetValues(typeof(OrderStatus))
                             .Cast<OrderStatus>()
                             .Select(e => OrderStatusDescriptions.StatusDescriptions[e])
                             .ToList();
            return Ok(statuses);
        }

        [HttpPut("UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id, string status)
        {
            var result = await orderService.UpdateOrderStatus(id, status);
            if (result) return Ok(result);
            return BadRequest(result);
        }
    }
}
