using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.AddressDtos;
using Shared.Mapping;

namespace Service;

internal sealed class AddressService : IAddressService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public AddressService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task<ViewAddressDto> GetAddressForJobAsync(Guid employerId, Guid jobId)
    {
        Job? job = await _repository.Job.GetJobForEmployerAsync(employerId,jobId);
        Address? address = await _repository.Address.GetAddressForJobAsync(job);
        return address.ToDto();
    
    }
    
    public async Task<ViewAddressDto> GetAddressForJobSeekerAsync(Guid jobSeekerId)
    {
        JobSeeker? jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        Address? address = await _repository.Address.GetAddressForJobSeekerAsync(jobSeeker);
        return address.ToDto();
    }
    
    public async Task<ViewAddressDto> AddAddressForJobAsync(Guid employerId, Guid jobId, AddAddressDto addressDto)
    {
        Address address = new Address();
        addressDto.ToEntity(address);
         _repository.Address.AddAddress(address);
         Job? job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
         if (job != null) job.AddressId = address.Id;
         await _repository.SaveAsync();
         return address.ToDto();
    }
    
    public async Task<ViewAddressDto> AddAddressForJobSeekerAsync(Guid jobSeekerId, AddAddressDto addressDto)
    {
        Address address = new Address();
        addressDto.ToEntity(address);
        _repository.Address.AddAddress(address);
        JobSeeker? jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        if (jobSeeker != null) jobSeeker.AddressId = address.Id;
        await _repository.SaveAsync();
        return address.ToDto();
    }
    
    public async Task DeleteAddressForJobAsync(Guid employerId, Guid jobId)
    {
        Job? job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        if (job?.Address is null) throw new NullReferenceException();
         _repository.Address.DeleteAddress(job.Address);
         await _repository.SaveAsync();
        
    }
    
    public async Task DeleteAddressForJobSeekerAsync(Guid jobSeekerId)
    {
        JobSeeker? jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        if (jobSeeker?.Address is null) throw new NullReferenceException();
        _repository.Address.DeleteAddress(jobSeeker.Address);
        await _repository.SaveAsync();
    }
    
    public async Task<ViewAddressDto> UpdateAddressForJobAsync(Guid employerId, Guid jobId, UpdateAddressDto addressDto)
    {
        Job? job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        if (job?.Address is null) throw new NullReferenceException();
        addressDto.ToEntity(job.Address);
        _repository.Address.UpdateAddress(job.Address);
        await _repository.SaveAsync();
        return job.Address.ToDto();
    
    }
    
    public async Task<ViewAddressDto>  UpdateAddressForJobSeekerAsync(Guid jobSeekerId, UpdateAddressDto addressDto)
    {
        JobSeeker? jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        if (jobSeeker?.Address is null) throw new NullReferenceException();
        addressDto.ToEntity(jobSeeker.Address);
        _repository.Address.UpdateAddress(jobSeeker.Address);
        await _repository.SaveAsync();
        return jobSeeker.Address.ToDto();
    }
    
}