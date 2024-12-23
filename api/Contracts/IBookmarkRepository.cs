using Entities.Models;

namespace Contracts;

public interface IBookmarkRepository
{
    Task<Bookmark> GetBookmarkAsync(Guid jobSeekerId, Guid jobId);
    Task<IEnumerable<Bookmark>> GetBookmarksForJobSeekerAsync(Guid jobSeekerId);
    Task AddBookmarkAsync(Bookmark bookmark);
    void UpdateBookmark(Bookmark bookmark);
    void DeleteBookmark(Bookmark bookmark);
}