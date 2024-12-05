using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(RepositoryContext context) : base(context){}


    public async Task<Address?> GetAddressForJobAsync(Job? job)
    {
        return await FindByCondition(a => job != null && a.Id.Equals(job.AddressId))
            .SingleOrDefaultAsync();
    }

    public async Task<Address?> GetAddressForJobSeekerAsync(JobSeeker? jobSeeker)
    {
        return await FindByCondition(a => jobSeeker != null && a.Id.Equals(jobSeeker.AddressId))
            .SingleOrDefaultAsync();
    }

    public void AddAddress(Address address)
    {
        Create(address);
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