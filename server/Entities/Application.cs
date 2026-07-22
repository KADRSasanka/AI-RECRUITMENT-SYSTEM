using System.ComponentModel.DataAnnotations;

namespace server.Entities
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        public int CandidateId { get; set; }

        public int JobId { get; set; }

        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Applied";

        public decimal? Score { get; set; }

        public string? RecruiterRemarks { get; set; }

        public string? AIRecommendation { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public Candidate? Candidate { get; set; }

        public Job? Job { get; set; }
    }
}