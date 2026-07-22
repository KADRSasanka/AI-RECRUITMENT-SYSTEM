namespace server.DTOs.ResumeProfile;


public class ResumeProfileResponseDto
{
    public int ResumeProfileId { get; set; }


    public int ResumeId { get; set; }


    public string? FullName { get; set; }


    public string? Email { get; set; }


    public string? PhoneNumber { get; set; }


    public string? Skills { get; set; }


    public string? Education { get; set; }


    public string? Experience { get; set; }


    public string? Certifications { get; set; }
}