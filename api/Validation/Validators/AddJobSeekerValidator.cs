using FluentValidation;
using Shared.DataTransferObjects.JobSeekerDtos;

namespace Validation.Validators;

public class AddJobSeekerValidator : AbstractValidator<AddJobSeekerDto>
{
    public AddJobSeekerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull();

        RuleFor(x => x.LastName)
            .NotNull();
        
        RuleFor(x => x.Gender)
            .NotNull();
    }
}