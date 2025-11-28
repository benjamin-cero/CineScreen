namespace CineScreen.Endpoints.CityEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.CityEndpoints.CityUpdateOrInsertEndpoint;

public class CityUpdateOrInsertValidator : AbstractValidator<CityUpdateOrInsertEndpoint.CityUpdateOrInsertRequest>
{
    public CityUpdateOrInsertValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("City name is required")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("City name can only contain letters and spaces")
            .MaximumLength(100).WithMessage("City name cannot exceed 100 characters");
    }
} 