using GlobalECommerce.Application.Payments.DTO;
using GlobalECommerce.Application.Payments.Interfaces;
using Microsoft.Extensions.Logging;

namespace GlobalECommerce.Application.Payments.Services;

public class PaymentService : IPaymentService
{
    private readonly ILogger<PaymentService> _logger;

    public PaymentService(
        ILogger<PaymentService> logger)
    {
        _logger = logger;
    }

    public async Task<PaymentResponse> ProcessAsync(
        PaymentRequest request)
    {
        _logger.LogInformation(
            "Processing payment of {Amount}",
            request.Amount);

        // simulate payment gateway delay
        await Task.Delay(2000);

        return new PaymentResponse
        {
            PaymentId = Guid.NewGuid().ToString(),

            Status = "Success",

            Message = "Payment Successful"
        };
    }
}