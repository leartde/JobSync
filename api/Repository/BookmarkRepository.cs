using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class BookmarkRepository : RepositoryBase<Bookmark>, IBookmarkRepository
{
    public BookmarkRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<Bookmark> GetBookmarkAsync(Guid jobSeekerId, Guid jobId)
    {
        return await FindByCondition(b => b.JobSeekerId.Equals(jobSeekerId)
                                          && b.JobId.Equals(jobId))
            .SingleAsync();
    }

    public async Task<IEnumerable<Bookmark>> GetBookmarksForJobSeekerAsync(Guid jobSeekerId)
    {
        return await FindByCondition(b => b.JobSeekerId.Equals(jobSeekerId))
            .Include(b => b.Job)
            .ThenInclude(j => j!.Employer)
            .Include(b => b.JobSeeker)
            .OrderBy(b => b.CreatedAt)
            .ToListAsync();
    }

    public async Task AddBookmarkAsync(Bookmark bookmark)
    {
        await Create(bookmark);
    }

    public void UpdateBookmark(Bookmark bookmark)
    {
       Update(bookmark);
    }

    public void DeleteBookmark(Bookmark bookmark)
    {
        Delete(bookmark);
    }
}