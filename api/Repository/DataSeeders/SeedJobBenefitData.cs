using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.DataSeeders;

public class SeedJobBenefitData : IEntityTypeConfiguration<JobBenefit>
{
    private static readonly Benefit[] jobBenefitEnums = Enum.GetValues(typeof(Benefit))
        .Cast<Benefit>().ToArray();
    
    private static readonly JobBenefit[] jobBenefits = new JobBenefit[SeedJobData.Jobs.Count * 2];
    public static IReadOnlyList<JobBenefit> JobBenefits => jobBenefits;
    
    public void Configure(EntityTypeBuilder<JobBenefit> builder)
    {
        int jobCount = SeedJobData.Jobs.Count;
        int benefitCount = Enum.GetNames(typeof(Benefit)).Length;
        int index = 0;
        for (int i = 0; i < jobCount; i++)
        {
            int[] benefitIndices = Enumerable.Range(0, benefitCount)
                .OrderBy(_ => Faker.Number.RandomNumber())
                .Take(2)
                .ToArray();
            for (int j = 0; j < 2; j++)
            {
                JobBenefit jobBenefit = new JobBenefit
                {
                    JobId = SeedJobData.Jobs[i].Id,
                    Benefit = jobBenefitEnums[benefitIndices[j]]
                };
                jobBenefits[index++] = jobBenefit;
            }
        }

        builder.HasData(jobBenefits);
    }
}