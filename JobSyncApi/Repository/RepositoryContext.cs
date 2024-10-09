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
    
        base.OnModelCreating(modelBuilder);
    }
    
}