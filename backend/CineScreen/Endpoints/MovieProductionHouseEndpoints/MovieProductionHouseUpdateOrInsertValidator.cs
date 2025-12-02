namespace CineScreen.Endpoints.MovieProductionHouseEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.MovieProductionHouseEndpoints.MovieProductionHouseUpdateOrInsertEndpoint;

public class MovieProductionHouseUpdateOrInsertValidator : AbstractValidator<MovieProductionHouseUpdateOrInsertEndpoint.MovieProductionHouseUpdateOrInsertRequest>
{
    public MovieProductionHouseUpdateOrInsertValidator()
    {
        RuleFor(x => x.MovieID)
            .GreaterThan(0).WithMessage("Movie ID must be greater than 0");

        RuleFor(x => x.ProductionHouseID)
            .GreaterThan(0).WithMessage("Production House ID must be greater than 0");
    }
} 