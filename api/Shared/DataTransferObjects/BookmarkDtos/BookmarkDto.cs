namespace Shared.DataTransferObjects.BookmarkDtos;

public abstract class BookmarkDto
{
    public Guid JobId { get; set; }
    public DateTime CreatedAt { get; set; }
}