namespace CineScreen.Endpoints.MenuEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.MenuEndpoints.MenuUpdateOrInsertEndpoint;

public class MenuUpdateOrInsertValidator : AbstractValidator<MenuUpdateOrInsertEndpoint.MenuUpdateOrInsertRequest>
{
    public MenuUpdateOrInsertValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .LessThanOrEqualTo(1000).WithMessage("Price cannot exceed 1000");
    }
} 