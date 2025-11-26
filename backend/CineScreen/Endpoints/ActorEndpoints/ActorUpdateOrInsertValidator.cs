namespace CineScreen.Endpoints.ActorEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.ActorEndpoints.ActorUpdateOrInsertEndpoint;

public class ActorUpdateOrInsertValidator : AbstractValidator<ActorUpdateOrInsertEndpoint.ActorUpdateOrInsertRequest>
{
    public ActorUpdateOrInsertValidator()
    {

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("First name can only contain letters and spaces")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");
    
    }
}
