using Entities.Enums;

namespace Shared.DataTransferObjects.ApplicationDtos;

public class ApplicationDto
{
    public Guid? JobId { get; set; }
    public ApplicationStatus? Status { get; set; }
    
}