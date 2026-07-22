namespace server.Features.Department.DTOs;

public class DepartmentResponse
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int OrganizationId { get; set; }

    public string OrganizationName { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}