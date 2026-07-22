using System.ComponentModel.DataAnnotations;

namespace server.Entities
{
    public class JobSkill
    {
        [Key]
        public int JobSkillId { get; set; }

        public int JobId { get; set; }

        public int SkillId { get; set; }

        public string? RequiredLevel { get; set; }

        public Job? Job { get; set; }

        public Skill? Skill { get; set; }
    }
}