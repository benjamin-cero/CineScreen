namespace CineScreen.Endpoints.MovieActorEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.MovieActorEndpoints.MovieActorUpdateOrInsertEndpoint;

public class MovieActorUpdateOrInsertValidator : AbstractValidator<MovieActorUpdateOrInsertEndpoint.MovieActorUpdateOrInsertRequest>
{
    public MovieActorUpdateOrInsertValidator()
    {
        RuleFor(x => x.MovieID)
            .GreaterThan(0).WithMessage("Movie ID must be greater than 0");

        RuleFor(x => x.ActorID)
            .GreaterThan(0).WithMessage("Actor ID must be greater than 0");
    }
} 