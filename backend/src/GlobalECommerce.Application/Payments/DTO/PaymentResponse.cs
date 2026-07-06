using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Payments.DTO
{
    public class PaymentResponse
    {
        public string PaymentId { get; set; } = "";

        public string Status { get; set; } = "";

        public string Message { get; set; } = "";
    }
}
