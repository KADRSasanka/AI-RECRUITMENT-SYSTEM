using Microsoft.EntityFrameworkCore;
using server.Entities;

namespace server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<CandidateSkill> CandidateSkills { get; set; }
    public DbSet<CandidateEducation> CandidateEducations { get; set; }
    public DbSet<CandidateExperience> CandidateExperiences { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobSkill> JobSkills { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<ResumeProfile> ResumeProfiles => Set<ResumeProfile>();
    public DbSet<CandidateMatch> CandidateMatches 
    => Set<CandidateMatch>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");
            entity.HasKey(r => r.RoleId);

            entity.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(r => r.Description)
                .HasMaxLength(250);

            entity.Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            entity.HasIndex(r => r.Name).IsUnique();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            entity.Property(u => u.IsActive)
                .HasDefaultValue(true);

            entity.Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            entity.HasIndex(u => u.Email).IsUnique();

            entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                RoleId = 1,
                Name = "Administrator",
                Description = "System Administrator",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Role
            {
                RoleId = 2,
                Name = "Recruiter",
                Description = "Recruitment Officer",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Role
            {
                RoleId = 3,
                Name = "Hiring Manager",
                Description = "Hiring Manager",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Role
            {
                RoleId = 4,
                Name = "Candidate",
                Description = "Job Applicant",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        modelBuilder.Entity<Candidate>()
            .HasOne(c => c.User)
            .WithOne()
            .HasForeignKey<Candidate>(c => c.UserId);


        modelBuilder.Entity<Candidate>()
            .Property(c => c.ExpectedSalary)
            .HasPrecision(18, 2);



        modelBuilder.Entity<CandidateSkill>()
            .HasOne(cs => cs.Candidate)
            .WithMany(c => c.Skills)
            .HasForeignKey(cs => cs.CandidateId);



        modelBuilder.Entity<CandidateSkill>()
            .HasOne(cs => cs.Skill)
            .WithMany(s => s.Candidates)
            .HasForeignKey(cs => cs.SkillId);



        modelBuilder.Entity<Resume>()
            .HasOne(r => r.Candidate)
            .WithOne(c => c.Resume)
            .HasForeignKey<Resume>(r => r.CandidateId);

        
        modelBuilder.Entity<Job>()
            .HasOne(j => j.Organization)
            .WithMany(o => o.Jobs)
            .HasForeignKey(j => j.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Job>()
            .HasOne(j => j.Department)
            .WithMany(d => d.Jobs)
            .HasForeignKey(j => j.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Job>()
            .HasOne(j => j.Recruiter)
            .WithMany()
            .HasForeignKey(j => j.RecruiterId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Job>()
            .HasOne(j => j.HiringManager)
            .WithMany()
            .HasForeignKey(j => j.HiringManagerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<JobSkill>()
            .HasOne(js => js.Job)
            .WithMany(j => j.JobSkills)
            .HasForeignKey(js => js.JobId);

        modelBuilder.Entity<JobSkill>()
            .HasOne(js => js.Skill)
            .WithMany()
            .HasForeignKey(js => js.SkillId);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.Candidate)
            .WithMany(c => c.Applications)
            .HasForeignKey(a => a.CandidateId);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.Job)
            .WithMany(j => j.Applications)
            .HasForeignKey(a => a.JobId);


        modelBuilder.Entity<Interview>()
            .HasOne(i => i.Application)
            .WithMany()
            .HasForeignKey(i => i.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Interview>()
            .HasOne(i => i.Interviewer)
            .WithMany()
            .HasForeignKey(i => i.InterviewerId)
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<ResumeProfile>()
            .HasOne(r => r.Resume)
            .WithOne(r => r.ResumeProfile)
            .HasForeignKey<ResumeProfile>(r => r.ResumeId);




        modelBuilder.Entity<CandidateMatch>()
            .HasOne(x => x.Candidate)
            .WithMany()
            .HasForeignKey(x => x.CandidateId)
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<CandidateMatch>()
            .HasOne(x => x.Job)
            .WithMany()
            .HasForeignKey(x => x.JobId)
            .OnDelete(DeleteBehavior.NoAction);

    }

    //private void OnDelete(DeleteBehavior restrict)
    //{
    //    throw new NotImplementedException();
    //}

}