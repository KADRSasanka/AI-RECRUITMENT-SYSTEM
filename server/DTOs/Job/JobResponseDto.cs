namespace server.DTOs.Job;


public class JobResponseDto
{

    public int JobId { get; set; }


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


    public string OrganizationName { get; set; } = string.Empty;


    public string DepartmentName { get; set; } = string.Empty;


}