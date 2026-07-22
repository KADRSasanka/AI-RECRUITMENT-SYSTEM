using server.DTOs.User;
using server.Repositories.Interfaces;
using server.Service.Interfaces;

namespace server.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserResponse>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();

        return users.Select(u => new UserResponse
        {
            UserId = u.UserId,
            FullName = $"{u.FirstName} {u.LastName}",
            Email = u.Email,
            Role = u.Role?.Name ?? "",
            IsActive = u.IsActive,
            CreatedAt = u.CreatedAt
        }).ToList();
    }

    public async Task<UserResponse?> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            return null;

        return new UserResponse
        {
            UserId = user.UserId,
            FullName = $"{user.FirstName} {user.LastName}",
            Email = user.Email,
            Role = user.Role?.Name ?? "",
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<bool> UpdateRoleAsync(
        int id,
        UpdateUserRoleRequest request)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            return false;

        user.RoleId = request.RoleId;
        user.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(user);

        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> UpdateStatusAsync(
        int id,
        UpdateUserStatusRequest request)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            return false;

        user.IsActive = request.IsActive;
        user.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(user);

        return await _repository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            return false;

        await _repository.DeleteAsync(user);

        return await _repository.SaveChangesAsync();
    }
}