namespace CineScreen.Endpoints.TicketEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.TicketEndpoints.TicketUpdateOrInsertEndpoint;

public class TicketUpdateOrInsertValidator : AbstractValidator<TicketUpdateOrInsertEndpoint.TicketUpdateOrInsertRequest>
{
    public TicketUpdateOrInsertValidator()
    {
        RuleFor(x => x.MyAppUserID)
            .GreaterThan(0).WithMessage("User ID must be greater than 0");

        RuleFor(x => x.SeatID)
            .GreaterThan(0).WithMessage("Seat ID must be greater than 0");

        RuleFor(x => x.ProjectionID)
            .GreaterThan(0).WithMessage("Projection ID must be greater than 0");

        RuleFor(x => x.OrderDate)
            .NotEmpty().WithMessage("Order date is required")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date cannot be in the future");
    }
} 