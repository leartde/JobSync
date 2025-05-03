using FluentValidation;
using Shared.DataTransferObjects.UserDtos;

namespace Validation.Validators.JobSeeker;

public class RegisterJobSeekerValidator : AbstractValidator<RegisterJobSeekerDto>
{
    public RegisterJobSeekerValidator()
    {
        RuleFor(x => x.JobSeeker)
            .SetValidator(new AddJobSeekerValidator());
    }
}