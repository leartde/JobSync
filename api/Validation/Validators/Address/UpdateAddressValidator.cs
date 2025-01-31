using FluentValidation;
using Maddalena;
using Shared.DataTransferObjects.AddressDtos;
using Validation.Validators.Employer;

namespace Validation.Validators.Address;

public class UpdateAddressValidator : AbstractValidator<UpdateAddressDto>
{
    public UpdateAddressValidator()
    {
        RuleFor(x => x.Country)
            .Must(IsACountry).WithError("Invalid country", "Please enter a valid country");

        RuleFor(x => x.City)
            .MinimumLength(2).WithError("Invalid city name length", "City name must be at least 2 characters long")
            .MaximumLength(50).WithError("Invalid city name length", "City name cannot exceed 50 characters")
            .When(x => x.City != null);

        RuleFor(x => x.ZipCode)
            .GreaterThanOrEqualTo(10000).WithError("Invalid ZIP code", "ZIP code must be 5 digits long")
            .LessThanOrEqualTo(99999).WithError("Invalid ZIP code", "ZIP code must be 5 digits long")
            .When(x => x.ZipCode != null);
    }

    private bool IsACountry(string? country)
    {
        IEnumerable<string> countries = Country.All.SelectMany(c => new[] { c.CommonName, c.OfficialName });
        return 
            string.IsNullOrEmpty(country) || countries.Contains(country, StringComparer.OrdinalIgnoreCase);
    }
}