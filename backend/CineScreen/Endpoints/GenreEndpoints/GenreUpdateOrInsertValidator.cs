namespace CineScreen.Endpoints.GenreEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.GenreEndpoints.GenreUpdateOrInsertEndpoint;

public class GenreUpdateOrInsertValidator : AbstractValidator<GenreUpdateOrInsertEndpoint.GenreUpdateOrInsertRequest>
{
    public GenreUpdateOrInsertValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Genre name is required")
            .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("Genre name can only contain letters and spaces")
            .MaximumLength(50).WithMessage("Genre name cannot exceed 50 characters");
    }
} 