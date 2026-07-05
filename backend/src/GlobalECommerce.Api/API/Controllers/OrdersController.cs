using Asp.Versioning;
using GlobalECommerce.Application.Orders.DTO;
using GlobalECommerce.Application.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalECommerce.Api.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrdersController(IOrderService service)
        {
            _service = service;
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var order = await _service.CreateAsync(request);

            return Ok(order);
        }
    }
}
