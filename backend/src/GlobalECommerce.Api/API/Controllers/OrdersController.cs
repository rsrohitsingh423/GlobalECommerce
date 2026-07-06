using Asp.Versioning;
using GlobalECommerce.Application.Orders.Commands.CreateOrder;
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
        private readonly CreateOrderHandler _handler;
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(IOrderService service, CreateOrderHandler handler, ILogger<OrdersController> logger)
        {
            _service = service;
            _handler = handler;
            _logger = logger;
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            _logger.LogInformation("POST /orders received.");
            var order = await _service.CreateAsync(request);

            return Ok(order);
        }
    }
}
