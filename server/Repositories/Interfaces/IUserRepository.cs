using server.Entities;

namespace server.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();

    Task<User?> GetByIdAsync(int id);

    Task UpdateAsync(User user);

    Task DeleteAsync(User user);

    Task<bool> SaveChangesAsync();
}