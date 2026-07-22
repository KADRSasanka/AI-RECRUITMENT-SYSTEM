using server.Entities;

namespace server.Interfaces;

public interface IResumeRepository
{
    Task<Resume?> GetByIdAsync(int id);

    Task<IEnumerable<Resume>> GetByCandidateIdAsync(int candidateId);

    Task<Resume> AddAsync(Resume resume);

    Task DeleteAsync(Resume resume);
}