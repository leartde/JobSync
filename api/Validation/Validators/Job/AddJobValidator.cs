using FluentValidation;
using Shared.DataTransferObjects.JobDtos;

namespace Validation.Validators.Job;

public class AddJobValidator : AbstractValidator<AddJobDto>
{
    public AddJobValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .MinimumLength(5).WithError("Invalid title length", "Title must be at least 5 characters long")
            .MaximumLength(40).WithError("Invalid title length", "Title length cannot exceed 40 characters");

        RuleFor(x => x.Pay)
            .NotNull()
            .Must(StartWithDollarSign).WithMessage("Pay must start with $ sign")
            .Must(EndsWithHourOrYear).WithMessage("Pay must be end with /year or /hour");

        RuleFor(x => x.Description)
            .NotNull()
            .MinimumLength(20).WithError("Invalid description length","Description must be at least 20 characters long")
            .MaximumLength(4000).WithError("Invalid description length","Description cannot exceed 4000 characters");
        
        
    }
    
    private bool StartWithDollarSign(string? pay)
    {
        return !string.IsNullOrEmpty(pay) && pay.StartsWith("$");
    }

    private bool EndsWithHourOrYear(string? pay)
    {
        return !string.IsNullOrEmpty(pay) && (pay.EndsWith("/year") || pay.EndsWith("/hour"));
    }
    
    
    
}