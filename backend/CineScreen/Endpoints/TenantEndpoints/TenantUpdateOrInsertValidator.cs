namespace CineScreen.Endpoints.TenantEndpoints;

using FluentValidation;
using static CineScreen.Endpoints.TenantEndpoints.TenantUpdateOrInsertEndpoint;

public class TenantUpdateOrInsertValidator : AbstractValidator<TenantUpdateOrInsertEndpoint.TenantUpdateOrInsertRequest>
{
    public TenantUpdateOrInsertValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

        RuleFor(x => x.DatabaseConnection)
            .NotEmpty().WithMessage("Database connection is required")
            .MaximumLength(500).WithMessage("Database connection cannot exceed 500 characters");

        RuleFor(x => x.ServerAddress)
            .NotEmpty().WithMessage("Server address is required")
            .MaximumLength(200).WithMessage("Server address cannot exceed 200 characters");
    }
} 