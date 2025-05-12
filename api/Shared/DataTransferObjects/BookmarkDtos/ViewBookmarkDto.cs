namespace Shared.DataTransferObjects.BookmarkDtos;

public class ViewBookmarkDto : BookmarkDto
{
    public string Job { get; set; } = string.Empty;
    public string Employer { get; set; } = string.Empty;
    public string JobSeeker { get; set; } = string.Empty;
    public Guid JobSeekerId { get; set; }
    public Guid EmployerId { get; set; }
}