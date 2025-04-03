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

        RuleFor(x => x.HourlyPay)
            .GreaterThanOrEqualTo(2).WithMessage("Minimum hourly pay is 2 dollars/hr")
            .LessThanOrEqualTo(200).WithMessage("Maximum hourly pay is 200 dollars/hr")
            .When(x => x.HourlyPay != null);

        RuleFor(x => x.Description)
            .MinimumLength(20).WithError("Invalid description length","Description must be at least 20 characters long")
            .MaximumLength(4000).WithError("Invalid description length","Description cannot exceed 4000 characters");
    }
    
    
}