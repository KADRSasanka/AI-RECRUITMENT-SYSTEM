using System.ComponentModel.DataAnnotations;

namespace server.Entities
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int RecruiterId { get; set; }

        //[Required]
        public int? HiringManagerId { get; set; }

        [Required]
        [MaxLength(150)]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        public string JobDescription { get; set; } = string.Empty;

        [MaxLength(100)]
        public string EmploymentType { get; set; } = string.Empty;

        [MaxLength(100)]
        public string WorkMode { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ExperienceLevel { get; set; } = string.Empty;

        public decimal? SalaryMin { get; set; }

        public decimal? SalaryMax { get; set; }

        [MaxLength(20)]
        public string Currency { get; set; } = "LKR";

        public int NumberOfVacancies { get; set; }

        public DateTime ClosingDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties

        public Organization? Organization { get; set; }

        public Department? Department { get; set; }

        public User? Recruiter { get; set; }

        public User? HiringManager { get; set; }

        public ICollection<JobSkill> JobSkills { get; set; }
            = new List<JobSkill>();

        public ICollection<Application> Applications { get; set; }
            = new List<Application>();
    }
}