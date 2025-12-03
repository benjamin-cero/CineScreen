namespace CineScreen.Endpoints.ProductionHouseEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.ProductionHouseEndpoints.ProductionHouseUpdateOrInsertEndpoint;

public class ProductionHouseUpdateOrInsertValidator : AbstractValidator<ProductionHouseUpdateOrInsertEndpoint.ProductionHouseUpdateOrInsertRequest>
{
    public ProductionHouseUpdateOrInsertValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Production house name is required")
            .MaximumLength(100).WithMessage("Production house name cannot exceed 100 characters");
    }
} 