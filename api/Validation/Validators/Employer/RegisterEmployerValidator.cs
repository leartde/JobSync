using System.Data;
using FluentValidation;
using Shared.DataTransferObjects.UserDtos;

namespace Validation.Validators.Employer;

public class RegisterEmployerValidator : AbstractValidator<RegisterEmployerDto>
{
    public RegisterEmployerValidator()
    {
        RuleFor(x => x.AddEmployerDto)
            .SetValidator(new AddEmployerValidator());

    }
}