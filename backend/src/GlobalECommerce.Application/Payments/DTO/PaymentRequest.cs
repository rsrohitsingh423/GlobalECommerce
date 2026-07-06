using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalECommerce.Application.Payments.DTO
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; } = "";

        public string CardHolderName { get; set; } = "";

        public string ExpiryMonth { get; set; } = "";

        public string ExpiryYear { get; set; } = "";

        public string CVV { get; set; } = "";

        public decimal Amount { get; set; }
    }
}
