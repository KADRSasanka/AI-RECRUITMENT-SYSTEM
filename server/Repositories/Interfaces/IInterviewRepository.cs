using server.Entities;


namespace server.Interfaces;


public interface IInterviewRepository
{

    Task<IEnumerable<Interview>> GetAllAsync();


    Task<Interview?> GetByIdAsync(int id);


    Task<IEnumerable<Interview>> GetByApplicationIdAsync(int applicationId);


    Task<Interview> AddAsync(Interview interview);


    Task UpdateAsync(Interview interview);


    Task DeleteAsync(Interview interview);

}