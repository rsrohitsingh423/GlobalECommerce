using Asp.Versioning;
using GlobalECommerce.Application.Payments.DTO;
using GlobalECommerce.Application.Payments.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalECommerce.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _service;

    public PaymentsController(IPaymentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<PaymentResponse>> Process(
        PaymentRequest request)
    {
        var response = await _service.ProcessAsync(request);

        return Ok(response);
    }
}   