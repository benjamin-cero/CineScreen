namespace CineScreen.Endpoints.ProjectionEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.ProjectionEndpoints.ProjectionUpdateOrInsertEndpoint;

public class ProjectionUpdateOrInsertValidator : AbstractValidator<ProjectionUpdateOrInsertEndpoint.ProjectionUpdateOrInsertRequest>
{
    public ProjectionUpdateOrInsertValidator()
    {
        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("Start time is required")
            .GreaterThan(DateTime.Now).WithMessage("Start time must be in the future");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .LessThanOrEqualTo(1000).WithMessage("Price cannot exceed 1000");

        RuleFor(x => x.MovieID)
            .GreaterThan(0).WithMessage("Movie ID must be greater than 0");

        RuleFor(x => x.CinemaHallID)
            .GreaterThan(0).WithMessage("Cinema hall ID must be greater than 0");

        RuleFor(x => x.MovieTypeID)
            .GreaterThan(0).WithMessage("Movie type ID must be greater than 0");
    }
} 