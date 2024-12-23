using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.DataSeeders;

public class SeedUserData : IEntityTypeConfiguration<AppUser>
{
    private readonly PasswordHasher<AppUser> passwordHasher = new();
    
    public static AppUser?[] Users = new AppUser[100];
    
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        
        for (int i = 0; i < 100; i++)
        {
            if (Users[i] == null)
            {
                string email = Faker.User.Email();
                AppUser user = new AppUser
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    UserName = email,
                    NormalizedUserName = email.ToUpper()
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Employerpass123");
                Users[i] = user;
            }

        }
        builder.HasData(Users);
    }
}