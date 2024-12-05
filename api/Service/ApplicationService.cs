using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.ApplicationDtos;
using Shared.Mapping;

namespace Service;

public class ApplicationService : IApplicationService
{
    private readonly IRepositoryManager _repository;

    public ApplicationService(IRepositoryManager repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobSeekerAsync(Guid jobSeekerId)
    {
        JobSeeker? jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        if (jobSeeker is null) throw new NullReferenceException();
        IEnumerable<Application> applications =
            await _repository.Application.GetApplicationsForJobSeekerAsync(jobSeeker);
        return applications.Select(a => a.MapApplicationDto());
    }

    public async Task<ViewApplicationDto> GetApplicationForJobSeekerAsync(Guid jobSeekerId, Guid applicationId)
    {
        JobSeeker? jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        if (jobSeeker is null) throw new NullReferenceException();
        Application? application =
            await _repository.Application.GetApplicationForJobSeekerAsync(jobSeeker, applicationId);
        return application.MapApplicationDto();
    }

    public async Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobAsync(Guid employerId, Guid jobId)
    {
        Job? job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        if (job is null) throw new NullReferenceException();
        IEnumerable<Application> applications = await _repository.Application.GetApplicationsForJobAsync(job);
        return applications.Select(a => a.MapApplicationDto());
    }

    public async Task<ViewApplicationDto> GetApplicationForJobAsync(Guid employerId, Guid jobId, Guid applicationId)
    {
        Job? job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        if (job is null) throw new NullReferenceException();
        Application? application = await _repository.Application.GetApplicationForJobAsync(job, applicationId);
        return application.MapApplicationDto();

    }

    public async Task<AddApplicationDto> AddApplicationAsync(AddApplicationDto applicationDto)
    {
        Application application = new Application();
        applicationDto.ReverseMapApplication(application);
        _repository.Application.AddApplication(application);
        await _repository.SaveAsync();
        return applicationDto;
    }

    public async Task<UpdateApplicationDto> UpdateApplicationAsync(UpdateApplicationDto applicationDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteApplicationAsync(Guid jobSeekerId, Guid applicationId)
    {
        throw new NotImplementedException();
    }
}