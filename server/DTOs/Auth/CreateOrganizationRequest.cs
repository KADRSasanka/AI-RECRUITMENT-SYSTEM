using System.ComponentModel.DataAnnotations;

namespace server.Features.Organization.DTOs;

public class CreateOrganizationRequest
{
    [Required]
    [MaxLength(200)]
    public string OrganizationName { get; set; } = "";

    public string Industry { get; set; } = "";

    public string Website { get; set; } = "";

    [EmailAddress]
    public string Email { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Address { get; set; } = "";

    public string Description { get; set; } = "";
}