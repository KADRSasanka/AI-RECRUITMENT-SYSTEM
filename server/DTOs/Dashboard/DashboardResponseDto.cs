namespace server.DTOs.Dashboard;

public class DashboardResponseDto
{
    public int TotalJobs { get; set; }

    public int ActiveJobs { get; set; }

    public int TotalCandidates { get; set; }

    public int TotalApplications { get; set; }

    public int PendingApplications { get; set; }

    public int ShortlistedApplications { get; set; }

    public int InterviewScheduled { get; set; }

    public int HiredCandidates { get; set; }
}