using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(RepositoryContext context) : base(context){}

    public async Task<IEnumerable<Address>> GetAllAddressesAsync()
    {
        return await FindAll().OrderBy(a => a.Country).ToListAsync();
    }

    public async Task<Address?> GetAddressAsync(Guid id)
    {
        return await FindByCondition(a => a.Id.Equals(id)).SingleOrDefaultAsync();
    }

    public void AddAddress(Address address)
    {
        Create(address);
    }

    public void DeleteAddress(Address address)
    {
        Delete(address);
    }

    public void UpdateAddress(Address? address)
    {
        Update(address);
    }
}