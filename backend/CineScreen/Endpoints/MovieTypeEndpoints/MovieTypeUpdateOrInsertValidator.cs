namespace CineScreen.Endpoints.MovieTypeEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.MovieTypeEndpoints.MovieTypeUpdateOrInsertEndpoint;

public class MovieTypeUpdateOrInsertValidator : AbstractValidator<MovieTypeUpdateOrInsertEndpoint.MovieTypeUpdateOrInsertRequest>
{
    public MovieTypeUpdateOrInsertValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Movie type is required")
            .MaximumLength(50).WithMessage("Movie type cannot exceed 50 characters");
    }
} 