using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.DataSeeders;

public class SeedJobSeekerSkillData : IEntityTypeConfiguration<JobSeekerSkill>
{
    private static readonly JobSeekerSkill[] jobSeekerSkills =
        new JobSeekerSkill[SeedJobSeekerData.JobSeekers.Count * 3];
    public static IReadOnlyList<JobSeekerSkill> JobSeekerSkills = jobSeekerSkills;

    public void Configure(EntityTypeBuilder<JobSeekerSkill> builder)
    {
        int jobSeekerCount = SeedJobSeekerData.JobSeekers.Count;
        int skillCount = SeedSkillData.Skills.Count;

        int index = 0;

        for (int i = 0; i < jobSeekerCount; i++)
        {
            int[] skillIndices = Enumerable.Range(0, skillCount)
                .OrderBy(_ => Faker.Number.RandomNumber())
                .Take(3)
                .ToArray();
          
            for (int j = 0; j < 3; j++)
            {
                JobSeekerSkill jobSkill = new JobSeekerSkill
                {
                    JobSeekersId = SeedJobSeekerData.JobSeekers[i].Id,
                    SkillsId = SeedSkillData.Skills[skillIndices[j]].Id
                };

                jobSeekerSkills[index++] = jobSkill;
            }
        }

        builder.HasData(jobSeekerSkills);
    }
}