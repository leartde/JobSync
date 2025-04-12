using FluentValidation;
using Shared.DataTransferObjects.EmployerDtos;

namespace Validation.Validators.Employer;

public class AddEmployerValidator : AbstractValidator<AddEmployerDto>
{
    public AddEmployerValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .MinimumLength(3).WithError("Invalid name length", "Name must be at least 3 characters long")
            .MaximumLength(35).WithError("Invalid name length", "Name cannot exceed 3 characters");
    }

}