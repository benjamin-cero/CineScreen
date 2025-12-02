namespace CineScreen.Endpoints.MovieGenreEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.MovieGenreEndpoints.MovieGenreUpdateOrInsertEndpoint;

public class MovieGenreUpdateOrInsertValidator : AbstractValidator<MovieGenreUpdateOrInsertEndpoint.MovieGenreUpdateOrInsertRequest>
{
    public MovieGenreUpdateOrInsertValidator()
    {
        RuleFor(x => x.MovieID)
            .GreaterThan(0).WithMessage("Movie ID must be greater than 0");

        RuleFor(x => x.GenreID)
            .GreaterThan(0).WithMessage("Genre ID must be greater than 0");
    }
} 