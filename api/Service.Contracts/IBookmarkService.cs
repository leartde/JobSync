using Shared.DataTransferObjects.BookmarkDtos;

namespace Service.Contracts;

public interface IBookmarkService
{
    Task<ViewBookmarkDto> GetBookmarkForJobSeekerAsync(Guid jobSeekerId,Guid jobId);
    Task<IEnumerable<ViewBookmarkDto>> GetBookmarksForJobSeekerAsync(Guid jobSeekerId);
    Task<ViewBookmarkDto> AddBookmarkForJobSeekerAsync(Guid jobSeekerId,Guid jobId);
    Task DeleteBookmarkForJobSeekerAsync(Guid jobSeekerId, Guid jobId);
}