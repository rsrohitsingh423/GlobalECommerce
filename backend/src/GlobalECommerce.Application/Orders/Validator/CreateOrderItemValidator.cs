using FluentValidation;
using GlobalECommerce.Application.Orders.DTO;

namespace GlobalECommerce.Application.Orders.Validators;

public class CreateOrderItemValidator
    : AbstractValidator<CreateOrderItemRequest>
{
    public CreateOrderItemValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity should be greater than zero.");
    }
}