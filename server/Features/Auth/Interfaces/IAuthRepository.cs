using server.Entities;

namespace server.Features.Auth.Interfaces;

public interface IAuthRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task<bool> EmailExistsAsync(string email);

    Task<User> CreateUserAsync(User user);

    Task SaveChangesAsync();
}