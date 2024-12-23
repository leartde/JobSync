using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.DataSeeders;

internal sealed class SeedEmployerData : IEntityTypeConfiguration<Employer>
{
    SeedUserData userData = new();

    public Employer[] Employers = new Employer[100];
    private readonly SeedUserData _userSeeder = new();

   
     
    
    public void Configure(EntityTypeBuilder<Employer> builder)
    {
        for (int i = 0; i < 100; i++)
        {
            if (SeedUserData.Users[i] == null) continue;
            Employer employer = new Employer
            {
                Id = Guid.NewGuid(),
                UserId = SeedUserData.Users[i]!.Id,
                Name = Faker.Name.FullName(),
                Country = Faker.Address.Country() ?? "Unknown",
                Industry = Faker.Company.Industry(),
                Founded = DateOnly.FromDateTime(Faker.Date.Birthday(1950, 2000)),
                Phone = Faker.Phone.GetPhoneNumber(),
                PhotoUrl = "https://picsum.photos/200/300"
            };
            Employers[i] = employer;
        }

        builder.HasData(Employers);
    }
}