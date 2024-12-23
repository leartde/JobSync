using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.BookmarkDtos;

namespace Presentation.Controllers;

[ApiController]
[Route("api/jobseeker/{jobSeekerId}/bookmarks")]
public class BookmarksController : ControllerBase
{
    private readonly IServiceManager _service;

    public BookmarksController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookmarksForJobSeeker(Guid jobSeekerId)
    {
        IEnumerable<ViewBookmarkDto> bookmarks =
            await _service.BookmarkService.GetBookmarksForJobSeekerAsync(jobSeekerId);
        return Ok(bookmarks);
    }

    [HttpGet("{jobId}")]
    public async Task<IActionResult> GetBookmark(Guid jobSeekerId, Guid jobId)
    {
        ViewBookmarkDto bookmark = await _service.BookmarkService.GetBookmarkForJobSeekerAsync(jobSeekerId, jobId);
        return Ok(bookmark);
    }

    [HttpPost]
    public async Task<IActionResult> AddBookmark(Guid jobSeekerId, AddBookmarkDto bookmarkDto)
    {
        ViewBookmarkDto bookmark =
            await _service.BookmarkService.AddBookmarkForJobSeekerAsync(jobSeekerId, bookmarkDto);
        return Ok(bookmark);
    }

    [HttpDelete("{jobId}")]
    public async Task<IActionResult> DeleteBookmark(Guid jobSeekerId, Guid jobId)
    {
        await _service.BookmarkService.DeleteBookmarkForJobSeekerAsync(jobSeekerId, jobId);
        return Ok();
    }
}