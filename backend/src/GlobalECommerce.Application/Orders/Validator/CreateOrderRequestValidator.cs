using FluentValidation;
using GlobalECommerce.Application.Orders.DTO;

namespace GlobalECommerce.Application.Orders.Validators;

public class CreateOrderRequestValidator
    : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.Items)
            .NotNull()
            .WithMessage("Order must contain at least one item.")
            .NotEmpty()
            .WithMessage("Order must contain at least one item.");

        RuleForEach(x => x.Items)
            .SetValidator(new CreateOrderItemValidator());
    }
}