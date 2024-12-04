using Entities.Models;

namespace Contracts;

public interface IAddressRepository
{
    // Task <IEnumerable<Address>> GetAllAddressesAsync();
    Task<Address?> GetAddressForJobAsync(Job? job);
    Task<Address?> GetAddressForJobSeekerAsync(JobSeeker? jobSeeker);
    void AddAddress(Address address);
    void DeleteAddress(Address address);
    void UpdateAddress(Address address);
}