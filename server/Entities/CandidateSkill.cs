namespace server.Entities;

public class CandidateSkill
{
    public int CandidateSkillId { get; set; }


    public int CandidateId { get; set; }


    public int SkillId { get; set; }


    public string? SkillLevel { get; set; }



    // Navigation

    public Candidate Candidate { get; set; } = null!;


    public Skill Skill { get; set; } = null!;
}