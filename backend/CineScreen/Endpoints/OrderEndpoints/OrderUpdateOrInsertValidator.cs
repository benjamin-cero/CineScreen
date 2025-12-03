namespace CineScreen.Endpoints.OrderEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.OrderEndpoints.OrderUpdateOrInsertEndpoint;

public class OrderUpdateOrInsertValidator : AbstractValidator<OrderUpdateOrInsertEndpoint.OrderUpdateOrInsertRequest>
{
    public OrderUpdateOrInsertValidator()
    {
        RuleFor(x => x.MyAppUserID)
            .GreaterThan(0).WithMessage("User ID must be greater than 0");

        RuleFor(x => x.MenuID)
            .GreaterThan(0).WithMessage("Menu ID must be greater than 0");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0")
            .LessThanOrEqualTo(100).WithMessage("Quantity cannot exceed 100");
    }
} 