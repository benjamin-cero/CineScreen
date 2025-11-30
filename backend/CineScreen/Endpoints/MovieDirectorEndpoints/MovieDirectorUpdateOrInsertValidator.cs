namespace CineScreen.Endpoints.MovieDirectorEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.MovieDirectorEndpoints.MovieDirectorUpdateOrInsertEndpoint;

public class MovieDirectorUpdateOrInsertValidator : AbstractValidator<MovieDirectorUpdateOrInsertEndpoint.MovieDirectorUpdateOrInsertRequest>
{
    public MovieDirectorUpdateOrInsertValidator()
    {
        RuleFor(x => x.MovieID)
            .GreaterThan(0).WithMessage("Movie ID must be greater than 0");

        RuleFor(x => x.DirectorID)
            .GreaterThan(0).WithMessage("Director ID must be greater than 0");
    }
} 