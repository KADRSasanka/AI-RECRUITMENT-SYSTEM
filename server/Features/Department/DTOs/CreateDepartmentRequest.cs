using System.ComponentModel.DataAnnotations;

namespace server.Features.Department.DTOs;

public class CreateDepartmentRequest
{
    [Required]
    [MaxLength(150)]
    public string DepartmentName { get; set; } = string.Empty;

    [MaxLength(300)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public int OrganizationId { get; set; }
}