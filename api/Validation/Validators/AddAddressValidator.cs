using FluentValidation;
using Shared.DataTransferObjects.AddressDtos;

namespace Validation.Validators;

public class AddAddressValidator : AbstractValidator<AddAddressDto>
{
    public AddAddressValidator()
    {
        RuleFor(x => x.Country)
            .NotNull();

        RuleFor(x => x.City)
            .NotNull();

        RuleFor(x => x.ZipCode)
            .NotNull();
        
    }
}