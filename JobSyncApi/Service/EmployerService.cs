using Contracts;
using Entities.Exceptions.AddressExceptions;
using Entities.Exceptions.EmployerExceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.EmployerDtos;
using Shared.Mapping;

namespace Service;

internal sealed class EmployerService : IEmployerService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public EmployerService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<ViewEmployerDto>> GetAllEmployersAsync()
    {
        IEnumerable<Employer> employers = await _repository.Employer.GetAllEmployersAsync();
        IEnumerable<ViewEmployerDto> employerDtos = employers.Select(e => e.MapEmployerDto());
        return employerDtos;
    }

    public async Task<ViewEmployerDto> GetEmployerAsync(Guid id)
    {
        Employer? employer = await _repository.Employer.GetEmployerAsync(id);
        if (employer is null) throw new EmployerNotFoundException(id);
        return employer.MapEmployerDto();
    }

    public async Task AddEmployerAsync(AddEmployerDto employerDto)
    {
        Address address = employerDto.Address.ReverseMapAddress();
        _repository.Address.AddAddress(address);
        Employer employer = employerDto.ReverseMapEmployer();
        _repository.Employer.AddEmployer(employer);
        await _repository.SaveAsync();

    }

    public async Task DeleteEmployerAsync(Guid id)
    {
        Employer? employer = await _repository.Employer.GetEmployerAsync(id);
        if (employer is null) throw new EmployerNotFoundException(id);
        _repository.Employer.DeleteEmployer(employer);
        await _repository.SaveAsync();
    }

    public async Task UpdateEmployerAsync(Guid id,UpdateEmployerDto employerDto)
    {
        Employer? employer = await _repository.Employer.GetEmployerAsync(id);
        if (employer is null) throw new EmployerNotFoundException(id);
        if (employer.Address != null)
        {
            Guid addressId = employer.Address.Id;
            employer = employerDto.ReverseMapEmployer();
            employer.Id = id;
            if (employer.Address != null) employer.Address.Id = addressId;
        }

        _repository.Address.UpdateAddress(employer.Address ?? throw new InvalidOperationException());
        _repository.Employer.UpdateEmployer(employer);
        await _repository.SaveAsync();
    }
}