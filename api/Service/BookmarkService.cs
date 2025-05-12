using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.BookmarkDtos;
using Shared.Mapping;

namespace Service;

internal sealed class BookmarkService : IBookmarkService
{
    private readonly IRepositoryManager _repository;
    public BookmarkService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<ViewBookmarkDto> GetBookmarkForJobSeekerAsync(Guid jobSeekerId, Guid jobId)
    {
        Bookmark bookmark = await _repository.Bookmark.GetBookmarkAsync(jobSeekerId, jobId);
        return bookmark.ToDto();
    }

    public async Task<IEnumerable<ViewBookmarkDto>> GetBookmarksForJobSeekerAsync(Guid jobSeekerId)
    {
        IEnumerable<Bookmark> bookmarks = await _repository.Bookmark.GetBookmarksForJobSeekerAsync(jobSeekerId);
        return bookmarks.Select(b => b.ToDto());
    }

    public async Task<ViewBookmarkDto> AddBookmarkForJobSeekerAsync(Guid jobSeekerId, Guid jobId)
    {
        Bookmark bookmark = new Bookmark
        {
            JobSeekerId = jobSeekerId,
            JobId = jobId,
        };
         await _repository.Bookmark.AddBookmarkAsync(bookmark);
         await _repository.SaveAsync();
         return bookmark.ToDto();
    }

    public async Task DeleteBookmarkForJobSeekerAsync(Guid jobSeekerId, Guid jobId)
    {
        Bookmark bookmark = await _repository.Bookmark.GetBookmarkAsync(jobSeekerId, jobId);
        _repository.Bookmark.DeleteBookmark(bookmark);
        await _repository.SaveAsync();
    }
}