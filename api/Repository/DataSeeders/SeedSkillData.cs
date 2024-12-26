using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.DataSeeders;

public class SeedSkillData : IEntityTypeConfiguration<Skill>
{
    // private static readonly Skill[] skills = new Skill[200];
    private static readonly Dictionary<int, string> skillEnums = Enum.GetValues(typeof(SkillEnum))
        .Cast<SkillEnum>()
        .ToDictionary(s => (int)s, s => s.ToString());
    private static readonly Skill[] skills = new Skill[skillEnums.Count];
    public static IReadOnlyList<Skill> Skills => skills;
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        foreach (KeyValuePair<int,string> skillEnum in skillEnums)
        {
            Skill skill = new Skill
            {
                Id = Guid.NewGuid(),
                Name = skillEnum.Value
            };
            skills[skillEnum.Key] = skill;
        }
        

        builder.HasData(skills);
    }
}