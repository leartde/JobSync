using Entities.Models;
using Shared.DataTransferObjects.BookmarkDtos;

namespace Shared.Mapping;

public static class BookmarkMapping
{
    public static ViewBookmarkDto ToDto(this Bookmark entity)
    {
        return new ViewBookmarkDto
        {
            JobSeekerId = entity.JobSeekerId,
            JobId = entity.JobId,
            CreatedAt = entity.CreatedAt,
            JobSeeker = $"{entity.JobSeeker?.FirstName} {entity.JobSeeker?.MiddleName} {entity.JobSeeker?.LastName}",
            Job = entity.Job?.Title ?? string.Empty
        };
    }

    public static void ToEntity(this BookmarkDto dto, Bookmark entity)
    {
        entity.JobId = dto.JobId;
        entity.CreatedAt = dto.CreatedAt;
    }
}