namespace server.DTOs.Job;

public class CreateJobDto
{
    public int OrganizationId { get; set; }

    public int DepartmentId { get; set; }

    public int RecruiterId { get; set; }

    public int HiringManagerId { get; set; }

    public string JobTitle { get; set; } = string.Empty;

    public string JobDescription { get; set; } = string.Empty;

    public string EmploymentType { get; set; } = string.Empty;

    public string WorkMode { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string ExperienceLevel { get; set; } = string.Empty;

    public decimal? SalaryMin { get; set; }

    public decimal? SalaryMax { get; set; }

    public string Currency { get; set; } = "LKR";

    public int NumberOfVacancies { get; set; }

    public DateTime ClosingDate { get; set; }
}