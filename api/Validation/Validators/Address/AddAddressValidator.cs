using FluentValidation;
using Maddalena;
using Shared.DataTransferObjects.AddressDtos;

namespace Validation.Validators.Address;

public class AddAddressValidator : AbstractValidator<AddAddressDto>
{
    public AddAddressValidator()
    {
        RuleFor(x => x.Country)
            .NotNull()
            .Must(IsACountry).WithError("Invalid country", "Please enter a valid country");

        RuleFor(x => x.City)
            .NotNull()
            .MinimumLength(2).WithError("Invalid city name length", "City name must be at least 2 characters long")
            .MaximumLength(50).WithError("Invalid city name length", "City name cannot exceed 50 characters");

        RuleFor(x => x.ZipCode)
            .NotNull()
            .GreaterThanOrEqualTo(10000).WithError("Invalid ZIP code", "ZIP code must be 5 digits long")
            .LessThanOrEqualTo(99999).WithError("Invalid ZIP code", "ZIP code must be 5 digits long");
    }

    private bool IsACountry(string? country)
    {
        IEnumerable<string> countries = Country.All.SelectMany(c => new[] { c.CommonName, c.OfficialName });
        return !string.IsNullOrEmpty(country) &&
               countries.Contains(country, StringComparer.OrdinalIgnoreCase);
    }

}