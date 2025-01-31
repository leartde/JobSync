using FluentValidation;
using Maddalena;
using Shared.DataTransferObjects.EmployerDtos;

namespace Validation.Validators.Employer;

public class UpdateEmployerValidator : AbstractValidator<UpdateEmployerDto>
{
    public UpdateEmployerValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3).WithError("Invalid name length", "Name must be at least 3 characters long")
            .MaximumLength(35).WithError("Invalid name length", "Name cannot exceed 3 characters")
            .When(x => x.Name != null);

        RuleFor(x => x.Country)
            .Must(IsACountry)
            .WithError("Invalid Country Error", "Please enter a valid country");
        
        RuleFor(x => x.UserId)
            .Null().WithError("UserId error", "UserId cannot be updated");
        
    }
    
    private bool IsACountry(string? country)
    {
        IEnumerable<string> countries = Country.All.SelectMany(c => new[] {c.CommonName , c.OfficialName});
        return string.IsNullOrEmpty(country) ||
               countries.Contains(country, StringComparer.OrdinalIgnoreCase);
    }
    
}