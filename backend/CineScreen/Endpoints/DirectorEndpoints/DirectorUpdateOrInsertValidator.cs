namespace CineScreen.Endpoints.DirectorEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.DirectorEndpoints.DirectorUpdateOrInsertEndpoint;

public class DirectorUpdateOrInsertValidator : AbstractValidator<DirectorUpdateOrInsertEndpoint.DirectorUpdateOrInsertRequest>
{
    public DirectorUpdateOrInsertValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("First name can only contain letters and spaces")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("Last name can only contain letters and spaces")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");
    }
} 