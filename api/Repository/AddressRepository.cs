using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(RepositoryContext context) : base(context){}


    public async Task<Address> GetAddressForJobAsync(Job job)
    {
        return await FindByCondition(a =>a.Id.Equals(job.AddressId))
            .SingleAsync();
    }

    public async Task<Address> GetAddressForJobSeekerAsync(JobSeeker jobSeeker)
    {
        return await FindByCondition(a => a.Id.Equals(jobSeeker.AddressId))
            .SingleAsync();
    }

    public async Task AddAddressAsync(Address address)
    {
        await Create(address);
    }

    public void DeleteAddress(Address address)
    {
        Delete(address);
    }

    public void UpdateAddress(Address address)
    {
        Update(address);
    }
}