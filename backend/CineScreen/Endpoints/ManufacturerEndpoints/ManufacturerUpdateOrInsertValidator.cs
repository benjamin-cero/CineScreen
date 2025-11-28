namespace CineScreen.Endpoints.ManufacturerEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.ManufacturerEndpoints.ManufacturerUpdateOrInsertEndpoint;

public class ManufacturerUpdateOrInsertValidator : AbstractValidator<ManufacturerUpdateOrInsertEndpoint.ManufacturerUpdateOrInsertRequest>
{
    public ManufacturerUpdateOrInsertValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Manufacturer name is required")
            .MaximumLength(100).WithMessage("Manufacturer name cannot exceed 100 characters");
    }
} 