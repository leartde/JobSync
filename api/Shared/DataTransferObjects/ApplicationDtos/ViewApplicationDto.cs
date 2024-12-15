using Entities.Enums;

namespace Shared.DataTransferObjects.ApplicationDtos;

public class ViewApplicationDto : ApplicationDto
{
    public Guid? JobSeekerId { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string Employer { get; set; } = string.Empty;
    public string Candidate { get; set; } = string.Empty;
    public string StatusString { get; set; } = string.Empty;

}