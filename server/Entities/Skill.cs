namespace server.Entities;

public class Skill
{
    public int SkillId { get; set; }


    public string SkillName { get; set; }
        = string.Empty;


    public ICollection<CandidateSkill> Candidates { get; set; }
        = new List<CandidateSkill>();
}