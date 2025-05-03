using Entities.Enums;

namespace Shared.DataTransferObjects.JobApplicationDtos;

public abstract class JobApplicationDto
{
    public Guid? JobId { get; set; }
    public ApplicationStatus? Status { get; set; }

     
    public override string ToString()
    {
        return $"JobId : {JobId}, Status : {Status.ToString()}";
    }
}