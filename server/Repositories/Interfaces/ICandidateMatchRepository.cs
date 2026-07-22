using server.Entities;

namespace server.Interfaces;


public interface ICandidateMatchRepository
{

    Task<CandidateMatch> AddAsync(
        CandidateMatch match);


    Task<IEnumerable<CandidateMatch>>
        GetByJobIdAsync(int jobId);


    Task<IEnumerable<CandidateMatch>>
        GetByCandidateIdAsync(int candidateId);

}