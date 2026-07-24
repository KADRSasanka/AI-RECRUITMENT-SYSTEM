using server.Entities;

namespace server.Repositories;

public interface IJobRepository
{
    Task<IEnumerable<Job>> GetAllAsync();

    Task<Job?> GetByIdAsync(int id);

    Task<IEnumerable<Job>> GetByOrganizationAsync(int organizationId);

    Task<IEnumerable<Job>> GetByDepartmentAsync(int departmentId);

    Task<IEnumerable<Job>> GetByHiringManagerIdAsync(int hiringManagerId);

    Task<IEnumerable<Job>> SearchAsync(string keyword);

    Task AddAsync(Job job);

    Task UpdateAsync(Job job);

    Task DeleteAsync(Job job);
}