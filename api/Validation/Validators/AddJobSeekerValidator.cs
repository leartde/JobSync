using FluentValidation;
using Microsoft.AspNetCore.Http;
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

        RuleFor(x => x.Resume)
            .Must(IsPdfOrWord)
            .WithError("File type error", "Resume must be in pdf or word format");
    }

    private bool IsPdfOrWord(IFormFile? file)
    {
        var type = Path.GetExtension(file?.FileName);
        return type is ".pdf" or ".doc" or ".docx";
    }
}