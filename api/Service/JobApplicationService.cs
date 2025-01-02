using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects.JobApplicationDtos;
using Shared.Mapping;

namespace Service;

public class JobApplicationService : IJobApplicationService
{
    private readonly IRepositoryManager _repository;

    public JobApplicationService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<ViewJobApplicationDto> GetApplicationAsync(Guid jobId, Guid jobSeekerId)
    {
        JobApplication jobApplication = await _repository.JobApplication.GetJobApplication(jobId, jobSeekerId);
        return jobApplication.ToDto();
    }

    public async Task<IEnumerable<ViewJobApplicationDto>> GetApplicationsForJobSeekerAsync(Guid jobSeekerId)
    {
        JobSeeker jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
        if (jobSeeker is null) throw new NullReferenceException();
        IEnumerable<JobApplication> applications =
            await _repository.JobApplication.GetApplicationsForJobSeekerAsync(jobSeeker);
        return applications.Select(a => a.ToDto());
    }
    

    public async Task<IEnumerable<ViewJobApplicationDto>> GetApplicationsForJobAsync(Guid employerId, Guid jobId)
    {
        Job job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        if (job is null) throw new NullReferenceException();
        IEnumerable<JobApplication> applications = await _repository.JobApplication.GetApplicationsForJobAsync(job);
        return applications.Select(a => a.ToDto());
    }
    

    public async Task<ViewJobApplicationDto> AddApplicationAsync(Guid jobSeekerId,AddJobApplicationDto jobApplicationDto)
    {
        JobApplication jobApplication = new JobApplication
        {
            JobSeekerId = jobSeekerId
        };
        jobApplicationDto.ToEntity(jobApplication);
        await _repository.JobApplication.AddApplicationAsync(jobApplication);
        await _repository.SaveAsync();
        return jobApplication.ToDto();
    }

    public async Task<ViewJobApplicationDto> UpdateApplicationAsync(UpdateJobApplicationDTO jobApplicationDto,
        Guid employerId, Guid jobId, Guid jobSeekerId)
    {
        Job job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
        JobApplication jobApplication = await _repository.JobApplication
            .GetJobApplication(job.Id, jobSeekerId);
        jobApplicationDto.ToEntity(jobApplication);
        _repository.JobApplication.UpdateApplication(jobApplication);
        await _repository.SaveAsync();
        return jobApplication.ToDto();
    }


    public async Task DeleteApplicationAsync(Guid jobId, Guid jobSeekerId)
    {
        JobApplication jobApplication = await _repository.JobApplication
            .GetJobApplication(jobId, jobSeekerId);
        _repository.JobApplication.DeleteApplication(jobApplication);
        await _repository.SaveAsync();
    }
}