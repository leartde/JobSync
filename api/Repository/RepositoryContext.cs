using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public RepositoryContext(DbContextOptions options) : base(options){}
    public DbSet<Employer>? Employers { get; set; }
    public DbSet<Job>? Jobs { get; set; }
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Application>? Applications { get; set; }
    public DbSet<Skill>? Skills { get; set; }
    public DbSet<JobSkill>? JobSkill { get; set; }
    public DbSet<JobSeekerSkill>? JobSeekerSkill { get; set; }
    public DbSet<Bookmark>? Bookmarks { get; set; }
    public DbSet<JobBenefit>? Benefits { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<JobSeeker>()
            .HasOne(js => js.User)
            .WithOne()
            .HasForeignKey<JobSeeker>(js => js.UserId);

        modelBuilder.Entity<Employer>()
            .HasOne(e => e.User)
            .WithOne()
            .HasForeignKey<Employer>(e => e.UserId);
        
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
        
        modelBuilder.Entity<JobSkill>()
            .HasKey(js => new { js.JobsId, js.SkillsId });

        modelBuilder.Entity<Bookmark>()
            .HasKey(b => new { b.JobId, b.JobSeekerId });

        modelBuilder.Entity<JobBenefit>()
            .HasKey(j => new { j.JobId, j.Benefit });
        
        modelBuilder.Entity<JobSeekerSkill>()
            .HasKey(js => new { js.JobSeekersId, js.SkillsId });
        

        modelBuilder.Entity<Job>()
            .HasMany(j => j.Skills)
            .WithMany(s => s.Jobs)
            .UsingEntity<JobSkill>();


        modelBuilder.Entity<JobSeeker>()
            .HasMany(j => j.Skills)
            .WithMany(s => s.JobSeekers)
            .UsingEntity<JobSeekerSkill>();
        
        
    
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    
}