using System.ComponentModel.DataAnnotations;

namespace server.Entities;

public class ResumeProfile
{
    [Key]
    public int ResumeProfileId { get; set; }


    public int ResumeId { get; set; }


    public string? FullName { get; set; }


    public string? Email { get; set; }


    public string? PhoneNumber { get; set; }


    public string? Skills { get; set; }


    public string? Education { get; set; }


    public string? Experience { get; set; }


    public string? Certifications { get; set; }


    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;



    public Resume? Resume { get; set; }
}