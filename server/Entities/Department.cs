using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Entities;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [Required]
    [MaxLength(150)]
    public string DepartmentName { get; set; } = "";

    [MaxLength(300)]
    public string Description { get; set; } = "";

    [ForeignKey(nameof(Organization))]
    public int OrganizationId { get; set; }

    public Organization Organization { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Job> Jobs { get; set; } = new List<Job>();
}