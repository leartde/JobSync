using Entities.Models;
using FluentValidation;
using Shared.DataTransferObjects.JobDtos;

namespace Validation.Validators;

public class AddJobValidator : AbstractValidator<AddJobDto>
{
    public AddJobValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .MinimumLength(5).WithMessage("Title must be at least 5 characters long")
            .MaximumLength(40).WithMessage("Title cannot exceed 40 characters");

        RuleFor(x => x.Pay)
            .NotNull()
            .Must(StartWithDollarSign).WithMessage("Pay must start with $ sign")
            .Must(EndsWithHourOrYear).WithMessage("Pay must be end with /year or /hour");

        RuleFor(x => x.Description)
            .NotNull()
            .MinimumLength(20).WithMessage("Description must be at least 20 characters long")
            .MaximumLength(4000).WithMessage("Description cannot exceed 4000 characters");
        
        
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