namespace server.DTOs.Candidate;

public class CandidateDashboardDto
{

    public int Applications { get; set; }

    public int Interviews { get; set; }

    public int Offers { get; set; }

    public int Rejected { get; set; }


    public CandidateInterviewDto? NextInterview { get; set; }


    public List<CandidateApplicationSummaryDto> RecentApplications { get; set; }
        = new();


    public List<CandidateJobSummaryDto> RecommendedJobs { get; set; }
        = new();

}


public class CandidateInterviewDto
{

    public string JobTitle { get; set; } = string.Empty;

    public string OrganizationName { get; set; } = string.Empty;

    public DateTime InterviewDate { get; set; }

    public string? MeetingLink { get; set; }

}



public class CandidateApplicationSummaryDto
{

    public int ApplicationId { get; set; }

    public string JobTitle { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

}



public class CandidateJobSummaryDto
{

    public int JobId { get; set; }

    public string JobTitle { get; set; } = string.Empty;

    public string OrganizationName { get; set; } = string.Empty;

}