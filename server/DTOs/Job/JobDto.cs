namespace server.DTOs.Job;

public class JobDto
{
    public int JobId { get; set; }


    public int OrganizationId { get; set; }

    public string? OrganizationName { get; set; }


    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }


    public int RecruiterId { get; set; }

    public string? RecruiterName { get; set; }


    public int HiringManagerId { get; set; }

    public string? HiringManagerName { get; set; }
    

    public string JobTitle { get; set; } = string.Empty;


    public string JobDescription { get; set; } = string.Empty;


    public string EmploymentType { get; set; } = string.Empty;


    public string WorkMode { get; set; } = string.Empty;


    public string Location { get; set; } = string.Empty;


    public string ExperienceLevel { get; set; } = string.Empty;


    public decimal? SalaryMin { get; set; }


    public decimal? SalaryMax { get; set; }


    public string Currency { get; set; } = string.Empty;


    public int NumberOfVacancies { get; set; }


    public DateTime ClosingDate { get; set; }


    public bool IsActive { get; set; }


    public DateTime CreatedAt { get; set; }
}