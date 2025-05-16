﻿using Entities.Models;
using Shared.DataTransferObjects.JobSeekerDtos;

namespace Shared.Mapping;

public static class JobSeekerMapping
{
    public static ViewJobSeekerDto ToDto(this JobSeeker entity)
    {
        return new ViewJobSeekerDto
        {
            Id = entity.Id,
            UserId = entity.UserId,
            FirstName = entity.FirstName,
            MiddleName = entity.MiddleName,
            LastName = entity.LastName,
            Phone = entity.Phone,
            Gender = entity.Gender,
            SecondaryPhone = entity.SecondaryPhone,
            Birthday = entity.Birthday,
            ResumeLink = entity.ResumeLink,
            ResumeName = entity.ResumeName,
            Skills = entity.Skills.Select(s => s.Name),
            JobApplications = entity.Applications.Select(a => a.ToDto()),
            Bookmarks = entity.Bookmarks.Select(b => b.JobId.ToString()),
            Address = entity.Address != null
                ? $"{entity.Address.Street}, {entity.Address.City},{entity.Address.State ??""}"
                  + $"{entity.Address.Country}, {entity.Address.ZipCode}"
                : ""
        };
    }

    public static void ToEntity(this JobSeekerDto dto,JobSeeker entity)
    {
        entity.FirstName = dto.FirstName;
        entity.MiddleName = dto.MiddleName;
        entity.LastName = dto.LastName;
        entity.Phone = dto.Phone;
        entity.Birthday = dto.Birthday;
        entity.Gender = dto.Gender;
        if (dto is AddJobSeekerDto addJobSeekerDto)
        {
            if (addJobSeekerDto.Address != null)
            {
                Address address = new Address();
                addJobSeekerDto.Address.ToEntity(address);
                entity.Address = address;
            }
        }
    }
}