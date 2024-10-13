using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options){}
    public DbSet<Job>? Jobs { get; set; }
    public DbSet<Employer>? Employers { get; set; }
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Application>? Applications { get; set; }
    public DbSet<Skill>? Skills { get; set; }
    public DbSet<JobSeekersSkills>? JobSeekersSkills { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>()
            .HasOne(e => e.Employer)
            .WithMany(j => j.Jobs)
            .HasForeignKey(e => e.EmployerId)
            .OnDelete(DeleteBehavior.NoAction);
        
     
        modelBuilder.Entity<Job>()
            .HasMany(a => a.Applications)
            .WithOne(j => j.Job)
            .HasForeignKey(a => a.JobId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<JobsSkills>()
            .HasKey(js => new { js.JobId, js.SkillId });
        modelBuilder.Entity<JobsSkills>()
            .HasOne(js => js.Job)
            .WithMany(j => j.Skills)
            .HasForeignKey(js => js.JobId);

        modelBuilder.Entity<JobsSkills>()
            .HasOne(js => js.Skill)
            .WithMany(s => s.Jobs)
            .HasForeignKey(js => js.SkillId);

        modelBuilder.Entity<JobSeekersSkills>()
            .HasKey(js => new { js.JobSeekerId, js.SkillId });

        modelBuilder.Entity<JobSeekersSkills>()
            .HasOne(js => js.JobSeeker)
            .WithMany(js => js.Skills)
            .HasForeignKey(js => js.JobSeekerId);

        modelBuilder.Entity<JobSeekersSkills>()
            .HasOne(js => js.Skill)
            .WithMany(js => js.JobSeekers)
            .HasForeignKey(js => js.SkillId);
            
    
        base.OnModelCreating(modelBuilder);
    }
    
}