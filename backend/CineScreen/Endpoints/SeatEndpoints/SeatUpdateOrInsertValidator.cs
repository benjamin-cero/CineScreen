namespace CineScreen.Endpoints.SeatEndpoints;

using CineScreen.Data.Models.SharedEnums;
using FluentValidation;
using static CineScreen.Endpoints.SeatEndpoints.SeatUpdateOrInsertEndpoint;

public class SeatUpdateOrInsertValidator : AbstractValidator<SeatUpdateOrInsertEndpoint.SeatUpdateOrInsertRequest>
{
    public SeatUpdateOrInsertValidator()
    {
        RuleFor(x => x.SeatNumber)
            .NotEmpty().WithMessage("Seat number is required")
            .MaximumLength(10).WithMessage("Seat number cannot exceed 10 characters");

        RuleFor(x => x.CinemaHallID)
            .GreaterThan(0).WithMessage("Cinema hall ID must be greater than 0");

        RuleFor(x => x.SeatType)
            .IsInEnum().WithMessage("Invalid seat type");
    }
} 