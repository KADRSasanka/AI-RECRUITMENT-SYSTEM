using server.Entities;


namespace server.Interfaces;


public interface IApplicationRepository
{

    Task<IEnumerable<Application>> GetAllAsync();


    Task<Application?> GetByIdAsync(int id);


    Task<IEnumerable<Application>> GetByCandidateIdAsync(int candidateId);


    Task<IEnumerable<Application>> GetByJobIdAsync(int jobId);


    Task<Application> AddAsync(Application application);


    Task<bool> ExistsAsync(int candidateId, int jobId);


    Task UpdateAsync(Application application);

}