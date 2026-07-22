using System.ComponentModel.DataAnnotations;

namespace server.Entities;

public class Organization
{
    [Key]
    public int OrganizationId { get; set; }

    [Required]
    [MaxLength(200)]
    public string OrganizationName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Industry { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Website { get; set; } = string.Empty;

    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(300)]
    public string Address { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    //Navigation
    public ICollection<Department> Departments { get; set; }
    = new List<Department>();
    public ICollection<Job> Jobs { get; set; } = new List<Job>();
}