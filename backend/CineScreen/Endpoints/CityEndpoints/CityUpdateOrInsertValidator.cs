namespace CineScreen.Endpoints.CityEndpoints;

using CineScreen.Data;
using FluentValidation;

public class CityUpdateOrInsertValidator : AbstractValidator<CityUpdateOrInsertEndpoint.CityUpdateOrInsertRequest>
{
    public CityUpdateOrInsertValidator(ApplicationDbContext dbContext)
    {
        // Validacija naziva grada
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Naziv grada je obavezan.")
            .MaximumLength(100).WithMessage("Naziv grada ne smije biti duži od 100 karaktera.")
            .Matches("^[a-zA-Z0-9 šđčćžŠĐČĆŽ-]+$").WithMessage("Naziv grada može sadržavati samo slova, brojeve, razmake i crtice.");


    }
}
