using System.ComponentModel.DataAnnotations;

namespace server.DTOs.Auth;

public class RegisterRequest
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = "";

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [MinLength(8)]
    public string Password { get; set; } = "";

    [Compare("Password")]
    public string ConfirmPassword { get; set; } = "";

    public int RoleId {get; set;}
}