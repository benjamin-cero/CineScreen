namespace CineScreen.Endpoints.CinemaHallEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.CinemaHallEndpoints.CinemaHallUpdateOrInsertEndpoint;

public class CinemaHallUpdateOrInsertValidator : AbstractValidator<CinemaHallUpdateOrInsertEndpoint.CinemaHallUpdateOrInsertRequest>
{
    public CinemaHallUpdateOrInsertValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Cinema hall name is required")
            .MaximumLength(100).WithMessage("Cinema hall name cannot exceed 100 characters");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("Capacity must be greater than 0")
            .LessThanOrEqualTo(500).WithMessage("Capacity cannot exceed 500 seats");
    }
} 