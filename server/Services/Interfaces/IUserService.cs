using server.DTOs.User;

namespace server.Service.Interfaces;

public interface IUserService
{
    Task<List<UserResponse>> GetAllAsync();

    Task<UserResponse?> GetByIdAsync(int id);

    Task<bool> UpdateRoleAsync(
        int id,
        UpdateUserRoleRequest request);

    Task<bool> UpdateStatusAsync(
        int id,
        UpdateUserStatusRequest request);

    Task<bool> DeleteAsync(int id);
}