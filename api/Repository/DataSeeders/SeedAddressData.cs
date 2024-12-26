using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.DataSeeders;

public class SeedAddressData : IEntityTypeConfiguration<Address>
{
    private static readonly Address[] addresses = new Address[200];
    public static IReadOnlyList<Address> Addresses => addresses;
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        for (int i = 0; i < 200; i++)
        {
            Address address = new Address
            {
                Id = Guid.NewGuid(),
                Street = Faker.Address.StreetName(),
                City = Faker.Address.USCity(),
                State = Faker.Address.State(),
                Country = "United States",
                ZipCode = int.Parse(Faker.Address.USZipCode())
            };
            addresses[i] = address;
        }

        builder.HasData(addresses);
    }
}
