namespace CineScreen.Endpoints.MovieEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.MovieEndpoints.MovieUpdateOrInsertEndpoint;

public class MovieUpdateOrInsertValidator : AbstractValidator<MovieUpdateOrInsertEndpoint.MovieUpdateOrInsertRequest>
{
    public MovieUpdateOrInsertValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Movie title is required")
            .MaximumLength(200).WithMessage("Movie title cannot exceed 200 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Movie description is required")
            .MaximumLength(1000).WithMessage("Movie description cannot exceed 1000 characters");

        RuleFor(x => x.Duration)
            .GreaterThan(0).WithMessage("Movie duration must be greater than 0")
            .LessThanOrEqualTo(300).WithMessage("Movie duration cannot exceed 300 minutes");

        When(x => !string.IsNullOrEmpty(x.Trailer), () =>
        {
            RuleFor(x => x.Trailer)
                .MaximumLength(500).WithMessage("Trailer URL cannot exceed 500 characters");
        });

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status value");
    }
} 