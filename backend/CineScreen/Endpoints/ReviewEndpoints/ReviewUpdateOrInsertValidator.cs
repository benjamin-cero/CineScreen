namespace CineScreen.Endpoints.ReviewEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.ReviewEndpoints.ReviewUpdateOrInsertEndpoint;

public class ReviewUpdateOrInsertValidator : AbstractValidator<ReviewUpdateOrInsertEndpoint.ReviewUpdateOrInsertRequest>
{
    public ReviewUpdateOrInsertValidator()
    {
        RuleFor(x => x.MyAppUserID)
            .GreaterThan(0).WithMessage("User ID must be greater than 0");

        RuleFor(x => x.MovieID)
            .GreaterThan(0).WithMessage("Movie ID must be greater than 0");

        RuleFor(x => x.Score)
            .InclusiveBetween(1, 10).WithMessage("Score must be between 1 and 10");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment is required")
            .MaximumLength(1000).WithMessage("Comment cannot exceed 1000 characters");

        RuleFor(x => x.ReviewDate)
            .NotEmpty().WithMessage("Review date is required")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Review date cannot be in the future");
    }
} 