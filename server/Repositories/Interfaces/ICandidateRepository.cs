using server.Entities;

namespace server.Repositories.Interfaces;

public interface ICandidateRepository
{

    Task<IEnumerable<Candidate>> GetAllAsync();


    Task<Candidate?> GetByIdAsync(int id);


    Task<Candidate> CreateAsync(Candidate candidate);


    Task UpdateAsync(Candidate candidate);


    Task DeleteAsync(Candidate candidate);

}