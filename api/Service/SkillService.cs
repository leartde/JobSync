// using Contracts;
// using Entities.Models;
// using Service.Contracts;
// using Shared.DataTransferObjects.SkillDtos;
// using Shared.Mapping;
//
// namespace Service;
//
// public class SkillService : ISkillService
// {
//     private readonly IRepositoryManager _repository;
//
//     public SkillService(IRepositoryManager repository)
//     {
//         _repository = repository;
//     }
//     public async Task<IEnumerable<ViewSkillDto>> AddSkillsForJobAsync(Guid employerId, Guid jobId, IEnumerable<AddSkillDto> skillDtos)
//     {
//         Job job = await _repository.Job.GetJobForEmployerAsync(employerId, jobId);
//         List<Skill> existingSkills = [];
//         List<Skill> newSkills = [];
//         foreach (AddSkillDto skillDto in skillDtos)
//         {
//             Skill? skill = await _repository.Skill.GetSkillByNameAsync(skillDto.Name);
//             if (skill != null) existingSkills.Add(skill);
//             else
//             {
//                 Skill newSkill = new Skill();
//                 skillDto.ToEntity(newSkill);
//                 newSkills.Add(newSkill);
//             }
//         }
//         if (newSkills.Count > 0)
//         {
//             await _repository.Skill.AddSkillsAsync(newSkills);
//             await _repository.SaveAsync();
//             foreach (Skill newSkill in newSkills)
//             {
//                 _repository.JobSkill.AddJobSkill(new JobSkill { SkillsId = newSkill.Id, JobsId = job.Id });
//             }
//         }
//         
//         foreach (Skill existingSkill in existingSkills)
//         {
//             _repository.JobSkill.AddJobSkill(new JobSkill { SkillsId = existingSkill.Id, JobsId = job.Id });
//         }
//
//         return existingSkills.Concat(newSkills).Select(s => s.ToDto());
//     }
//
//     public async Task<IEnumerable<ViewSkillDto>> AddSkillsForJobSeekerAsync(Guid jobSeekerId, IEnumerable<AddSkillDto> skillDtos)
//     {
//         JobSeeker jobSeeker = await _repository.JobSeeker.GetJobSeekerAsync(jobSeekerId);
//         List<Skill> existingSkills = [];
//         List<Skill> newSkills = [];
//         foreach (AddSkillDto skillDto in skillDtos)
//         {
//             Skill? skill = await _repository.Skill.GetSkillByNameAsync(skillDto.Name);
//             if (skill != null) existingSkills.Add(skill);
//             else
//             {
//                 Skill newSkill = new Skill();
//                 skillDto.ToEntity(newSkill);
//                 newSkills.Add(newSkill);
//             }
//         }
//
//         if (newSkills.Count > 0)
//         {
//             await _repository.Skill.AddSkillsAsync(newSkills);
//             await _repository.SaveAsync();
//             foreach (Skill newSkill in newSkills)
//             {
//                 _repository.JobSeekerSkill.AddJobSeekerSkill(new JobSeekerSkill
//                     { SkillsId = newSkill.Id, JobSeekersId = jobSeeker.Id });
//             }
//         }
//
//         foreach (Skill existingSkill in existingSkills)
//         {
//             _repository.JobSeekerSkill.AddJobSeekerSkill(new JobSeekerSkill
//                 { SkillsId = existingSkill.Id, JobSeekersId = jobSeeker.Id });
//         }
//         return existingSkills.Concat(newSkills).Select(s => s.ToDto());
//     }
//
//     public async Task DeleteSkillsForJobAsync(Guid employerId, Guid jobId, List<Guid> skillIds)
//     {
//         List<Skill> skills = await _repository.Skill.GetSkillsByIdAsync(skillIds);
//         _repository.Skill.DeleteSkills(skills);
//     }
//
//     public async Task DeleteSkillsForJobSeekerAsync(Guid jobSeekerId, List<Guid> skillIds)
//     {
//         throw new NotImplementedException();
//     }
// }