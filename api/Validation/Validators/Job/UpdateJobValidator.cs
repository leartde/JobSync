using FluentValidation;
using Shared.DataTransferObjects.JobDtos;

namespace Validation.Validators.Job;

public class UpdateJobValidator : AbstractValidator<UpdateJobDto>
{
    public UpdateJobValidator()
    {
        RuleFor(x => x.Title)
            .MinimumLength(5).WithError("Invalid title length","Title must be at least 5 characters long")
            .MaximumLength(40).WithError("Invalid title length","Title length cannot exceed 40 characters")
            .When(x => x.Title != null);

        RuleFor(x => x.Pay)
            .Must(StartWithDollarSign).WithError("Invalid pay format","Pay must start with $")
            .Must(EndsWithHourOrYear).WithError("Invalid pay format","Pay must end with /year or /hour")
            .When(x => x.Pay != null);

        RuleFor(x => x.Description)
            .MinimumLength(20).WithError("Invalid description length","Description must be at least 20 characters long")
            .MaximumLength(4000).WithError("Invalid description length","Description cannot exceed 4000 characters");
    }
    
    private bool StartWithDollarSign(string? pay)
    {
        return pay is null || pay.StartsWith('$');
    }

    private bool EndsWithHourOrYear(string? pay)
    {
        return pay is null || pay.EndsWith("/year") || pay.EndsWith("/hour");
    }
    
}