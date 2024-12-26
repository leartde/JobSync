using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.DataSeeders;

public class SeedJobSkillData : IEntityTypeConfiguration<JobSkill>
{
    private static readonly JobSkill[] jobSkills = new JobSkill[SeedJobData.Jobs.Count * 3];
    public static IReadOnlyList<JobSkill> JobSkills = jobSkills;

    public void Configure(EntityTypeBuilder<JobSkill> builder)
    {
        int jobCount = SeedJobData.Jobs.Count;
        int skillCount = SeedSkillData.Skills.Count;

        int index = 0;

        for (int i = 0; i < jobCount; i++)
        {
            int[] skillIndices = Enumerable.Range(0, skillCount)
                .OrderBy(_ => Faker.Number.RandomNumber())
                .Take(3)
                .ToArray();
          
            for (int j = 0; j < 3; j++)
            {
                JobSkill jobSkill = new JobSkill
                {
                    JobsId = SeedJobData.Jobs[i].Id,
                    SkillsId = SeedSkillData.Skills[skillIndices[j]].Id
                };

                jobSkills[index++] = jobSkill;
            }
        }

        builder.HasData(jobSkills);
    }
}