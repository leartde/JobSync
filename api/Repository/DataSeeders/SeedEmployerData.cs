using Entities.Enums;
using Entities.Models;
using Faker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.DataSeeders;

internal sealed class SeedEmployerData : IEntityTypeConfiguration<Employer>
{
    private static readonly Employer[] employers = new Employer[100];
    public static IReadOnlyList<Employer> Employers => employers;
    
    
    public void Configure(EntityTypeBuilder<Employer> builder)
    {
        for (int i = 0; i < 100; i++)
        {
            Employer employer = new Employer
            {
                Id = Guid.NewGuid(),
                UserId = SeedUserData.Users[i].Id,
                Name = Name.FullName(),
                Email = $"{Name.FullName()}@gmail.com",
                Description = Lorem.Paragraph(40),
                Country = Faker.Address.Country() ?? "Unknown",
                Industry = (Industry)Number.RandomNumber(0,15),
                Founded = DateOnly.FromDateTime(Date.Birthday(0, 50)),
                Phone = Phone.GetPhoneNumber(),
                PhotoUrl = "https://picsum.photos/200/300"
            };
            employers[i] = employer;
        }

        builder.HasData(employers);
    }
}