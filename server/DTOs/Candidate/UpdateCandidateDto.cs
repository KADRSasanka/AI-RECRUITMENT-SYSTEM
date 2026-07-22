namespace server.DTOs.Candidate;

public class UpdateCandidateDto
{

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
}