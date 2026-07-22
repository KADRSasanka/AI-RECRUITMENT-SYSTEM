namespace server.Entities;

public class Candidate
{
    public int CandidateId { get; set; }


    public int UserId { get; set; }


    public DateTime? DateOfBirth { get; set; }


    public string? Gender { get; set; }


    public string? Nationality { get; set; }


    public string? CurrentPosition { get; set; }


    public string? CurrentCompany { get; set; }


    public int YearsOfExperience { get; set; }


    public decimal? ExpectedSalary { get; set; }


    public string? Availability { get; set; }


    public string? LinkedInUrl { get; set; }


    public string? GitHubUrl { get; set; }


    public string? PortfolioUrl { get; set; }


    public string? ProfileSummary { get; set; }


    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation

    public User User { get; set; } = null!;


    public ICollection<CandidateSkill> Skills { get; set; }
        = new List<CandidateSkill>();


    public ICollection<CandidateEducation> Educations { get; set; }
        = new List<CandidateEducation>();


    public ICollection<CandidateExperience> Experiences { get; set; }
        = new List<CandidateExperience>();


    public ICollection<Application> Applications { get; set; } 
        = new List<Application>();
        
    public ICollection<Resume> Resumes { get; set; }
        = new List<Resume>();

    public Resume? Resume { get; set; }

}