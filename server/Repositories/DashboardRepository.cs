using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Dashboard;
using server.Interfaces;

namespace server.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly ApplicationDbContext _context;

    public DashboardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardResponseDto> GetDashboardAsync()
    {
        return new DashboardResponseDto
        {
            TotalJobs = await _context.Jobs.CountAsync(),

            ActiveJobs = await _context.Jobs
                .CountAsync(j => j.IsActive),

            TotalCandidates = await _context.Candidates.CountAsync(),

            TotalApplications = await _context.Applications.CountAsync(),

            PendingApplications = await _context.Applications
                .CountAsync(a => a.Status == "Pending"),

            ShortlistedApplications = await _context.Applications
                .CountAsync(a => a.Status == "Shortlisted"),

            InterviewScheduled = await _context.Interviews
                .CountAsync(),

            HiredCandidates = await _context.Applications
                .CountAsync(a => a.Status == "Hired")


        };

    }
}