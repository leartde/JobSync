using Entities.Models;
using Shared.DataTransferObjects.ApplicationDtos;

namespace Shared.Mapping;

public static class ApplicationMapping
{
    public static ViewApplicationDto ToDto(this JobApplication entity)
    {
        return new ViewApplicationDto
        {
           JobId = entity.JobId,
            JobSeekerId = entity.JobSeekerId,
            Employer = entity.Job?.Employer?.Name ?? string.Empty,
            JobTitle = entity.Job?.Title ?? string.Empty,
            Candidate = $"{entity.JobSeeker?.FirstName ?? string.Empty}" +
                        $"{entity.JobSeeker?.MiddleName ?? string.Empty}" +
                        $"{entity.JobSeeker?.LastName ?? string.Empty} ",
            StatusString = entity.Status.ToString()
            
        };
    }

    public static void ToEntity(this ApplicationDto dto, JobApplication entity)
    {
        entity.JobId = dto.JobId ?? entity.JobId;
        entity.Status = dto.Status ?? entity.Status;

    }
    
    }