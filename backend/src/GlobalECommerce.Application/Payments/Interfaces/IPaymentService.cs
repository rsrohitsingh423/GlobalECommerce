using GlobalECommerce.Application.Payments.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Payments.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponse> ProcessAsync(PaymentRequest request);
    }
}
