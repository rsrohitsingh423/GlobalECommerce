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
        public OrdersController(IOrderService service, CreateOrderHandler handler)
        {
            _service = service;
            _handler = handler;
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var order = await _service.CreateAsync(request);

            return Ok(order);
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(CreateOrderRequest request)
        //{
        //    var response = await _handler.Handle(request);

        //    return Ok(response);
        //}
    }
}
