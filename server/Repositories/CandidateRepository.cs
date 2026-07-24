using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Candidate;
using server.Entities;
using server.Repositories.Interfaces;

namespace server.Repositories;


public class CandidateRepository : ICandidateRepository
{

    private readonly ApplicationDbContext _context;


    public CandidateRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }




    public async Task<IEnumerable<Candidate>> GetAllAsync()
    {
        return await _context.Candidates
            .ToListAsync();
    }





    public async Task<Candidate?> GetByIdAsync(int id)
    {
        return await _context.Candidates
            .FirstOrDefaultAsync(x =>
            x.CandidateId == id);
    }





    public async Task<Candidate> CreateAsync(
        Candidate candidate)
    {

        await _context.Candidates.AddAsync(candidate);

        await _context.SaveChangesAsync();

        return candidate;
    }





    public async Task UpdateAsync(
        Candidate candidate)
    {
        _context.Candidates.Update(candidate);

        await _context.SaveChangesAsync();
    }





    public async Task DeleteAsync(
        Candidate candidate)
    {

        _context.Candidates.Remove(candidate);

        await _context.SaveChangesAsync();

    }






    // ============================
    // Candidate Dashboard
    // ============================

    public async Task<CandidateDashboardDto> GetDashboardAsync(
        int candidateId)
    {


        var applications =
            await _context.Applications

            .Include(a => a.Job)

            .Where(a =>
                a.CandidateId == candidateId)

            .OrderByDescending(a =>
                a.CreatedAt)

            .ToListAsync();






        var interviews =
            await _context.Interviews

            .Include(i => i.Application)
                .ThenInclude(a => a!.Job)
                    .ThenInclude(j => j!.Organization)

            .Where(i =>
                i.Application!.CandidateId == candidateId)

            .OrderBy(i =>
                i.InterviewDate)

            .ToListAsync();








        var recommendedJobs =
            await _context.Jobs

            .Include(j =>
                j.Organization)

            .Where(j =>
                j.IsActive)

            .OrderByDescending(j =>
                j.CreatedAt)

            .Take(3)

            .ToListAsync();








        return new CandidateDashboardDto
        {

            Applications =
                applications.Count,



            Interviews =
                interviews.Count,



            Offers =
                applications.Count(a =>
                    a.Status == "Hired"),



            Rejected =
                applications.Count(a =>
                    a.Status == "Rejected"),





            NextInterview =
                interviews

                .Where(i =>
                    i.InterviewDate >= DateTime.UtcNow)

                .Select(i =>
                    new CandidateInterviewDto
                    {

                        JobTitle =
                        i.Application!.Job!.JobTitle,



                        OrganizationName =
                        i.Application.Job.Organization!.OrganizationName,



                        InterviewDate =
                        i.InterviewDate,



                        MeetingLink =
                        i.MeetingLink

                    })

                .FirstOrDefault(),






            RecentApplications =
                applications

                .Take(5)

                .Select(a =>
                    new CandidateApplicationSummaryDto
                    {

                        ApplicationId =
                            a.ApplicationId,


                        JobTitle =
                            a.Job!.JobTitle,


                        Status =
                            a.Status

                    })

                .ToList(),








            RecommendedJobs =
                recommendedJobs

                .Select(j =>
                    new CandidateJobSummaryDto
                    {

                        JobId =
                            j.JobId,


                        JobTitle =
                            j.JobTitle,


                        OrganizationName =
                            j.Organization!.OrganizationName

                    })

                .ToList()

        };

    }

}