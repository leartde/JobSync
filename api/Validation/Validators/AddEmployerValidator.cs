using FluentValidation;
using Maddalena;
using Shared.DataTransferObjects.EmployerDtos;
using Tingle.Extensions.PhoneValidators.Abstractions;
using Tingle.Extensions.PhoneValidators.Safaricom;
using Tingle.Extensions.PhoneValidators.Telkom;

namespace Validation.Validators;

public class AddEmployerValidator : AbstractValidator<AddEmployerDto>
{
    public AddEmployerValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .MinimumLength(3).WithError("Invalid name length","Name must be at least 3 characters long")
            .MaximumLength(35).WithError("Invalid name length", "Name cannot exceed 3 characters");
        
        RuleFor(x => x.Name)
            .NotNull()
            .MinimumLength(3).WithError("Invalid number length","Name must be at least 3 characters long")
            .MaximumLength(35).WithError("invalid number length" ,"Name cannot exceed 3 characters");

        RuleFor(x => x.Country)
            .NotNull()
            .Must(IsACountry)
            .WithError("Invalid Country Error", "Please enter a valid country");

            RuleFor(x => x.Phone)
                .NotNull();
    }
    
    private bool IsACountry(string? country)
    {
        IEnumerable<string> countries = Country.All.SelectMany(c => new[] {c.CommonName , c.OfficialName});
        return !string.IsNullOrEmpty(country) &&
               countries.Contains(country, StringComparer.OrdinalIgnoreCase);
    }

   
    
}