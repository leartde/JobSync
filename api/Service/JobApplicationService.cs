using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.ApplicationDtos;
using Shared.Mapping;

namespace Service;

public class JobApplicationService : IJobApplicationService
{
    private readonly IRepositoryManager _repository;

    public JobApplicationService(IRepositoryManager repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobSeekerAsync(Guid jobSeekerId)
    {
        JobSeeker? jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        if (jobSeeker is null) throw new NullReferenceException();
        IEnumerable<JobApplication> applications =
            await _repository.JobApplication.GetApplicationsForJobSeekerAsync(jobSeeker);
        return applications.Select(a => a.MapApplicationDto());
    }
    

    public async Task<IEnumerable<ViewApplicationDto>> GetApplicationsForJobAsync(Guid employerId, Guid jobId)
    {
        Job? job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        if (job is null) throw new NullReferenceException();
        IEnumerable<JobApplication> applications = await _repository.JobApplication.GetApplicationsForJobAsync(job);
        return applications.Select(a => a.MapApplicationDto());
    }
    

    public async Task<ViewApplicationDto> AddApplicationAsync(Guid jobSeekerId,AddApplicationDto applicationDto)
    {
        JobApplication jobApplication = new JobApplication
        {
            JobSeekerId = jobSeekerId
        };
        applicationDto.ReverseMapApplication(jobApplication);
        _repository.JobApplication.AddApplication(jobApplication);
        await _repository.SaveAsync();
        return jobApplication.MapApplicationDto();
    }

    public async Task<ViewApplicationDto> UpdateApplicationAsync(UpdateApplicationDto applicationDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteApplicationAsync(Guid jobSeekerId, Guid applicationId)
    {
        throw new NotImplementedException();
    }
}