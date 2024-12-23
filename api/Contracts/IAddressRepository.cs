using Entities.Models;

namespace Contracts;

public interface IAddressRepository
{
    
    Task<Address> GetAddressForJobAsync(Job job);
    Task<Address> GetAddressForJobSeekerAsync(JobSeeker jobSeeker);
    Task AddAddressAsync(Address address);
    void DeleteAddress(Address address);
    void UpdateAddress(Address address);
}