using FluentValidation;
using Shared.DataTransferObjects.UserDtos;

namespace Validation.Validators.JobSeeker;

public class RegisterJobSeekerValidator : AbstractValidator<RegisterJobSeekerDto>
{
    public RegisterJobSeekerValidator()
    {
        RuleFor(x => x.AddJobSeekerDto)
            .SetValidator(new AddJobSeekerValidator());
    }
}