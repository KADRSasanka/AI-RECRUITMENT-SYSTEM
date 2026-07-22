using server.Common;
using server.DTOs.Auth;

namespace server.Features.Auth.Interfaces;

public interface IAuthService
{
    Task<ApiResponse> RegisterAsync(RegisterRequest request);

    Task<LoginResponse?> LoginAsync(LoginRequest request);
}