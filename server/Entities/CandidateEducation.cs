namespace server.Entities;

public class CandidateEducation
{
    public int CandidateEducationId { get; set; }


    public int CandidateId { get; set; }


    public string Institution { get; set; }
        = string.Empty;


    public string Degree { get; set; }
        = string.Empty;


    public string FieldOfStudy { get; set; }
        = string.Empty;


    public DateTime? StartDate { get; set; }


    public DateTime? EndDate { get; set; }



    public Candidate Candidate { get; set; } = null!;
}