namespace CineScreen.Endpoints.MenuManufacturerEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.MenuManufacturerEndpoints.MenuManufacturerUpdateOrInsertEndpoint;

public class MenuManufacturerUpdateOrInsertValidator : AbstractValidator<MenuManufacturerUpdateOrInsertEndpoint.MenuManufacturerUpdateOrInsertRequest>
{
    public MenuManufacturerUpdateOrInsertValidator()
    {
        RuleFor(x => x.MenuID)
            .GreaterThan(0).WithMessage("Menu ID must be greater than 0");

        RuleFor(x => x.ManufacturerID)
            .GreaterThan(0).WithMessage("Manufacturer ID must be greater than 0");
    }
} 