using server.Common;
using server.DTOs.Auth;
using server.Entities;
using server.Features.Auth.Interfaces;

namespace server.Features.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repository;
    private readonly IJwtService _jwtService;

    public AuthService(
        IAuthRepository repository,
        IJwtService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }

    public async Task<ApiResponse> RegisterAsync(RegisterRequest request)
    {
        if (await _repository.EmailExistsAsync(request.Email))
        {
            return new ApiResponse
            {
                Success = false,
                Message = "Email already exists."
            };
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            RoleId = 4,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.CreateUserAsync(user);
        await _repository.SaveChangesAsync();

        return new ApiResponse
        {
            Success = true,
            Message = "Registration successful."
        };
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var user = await _repository.GetByEmailAsync(request.Email);

        if (user == null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(
            request.Password,
            user.PasswordHash))
            return null;

        return new LoginResponse
        {
            Token = _jwtService.GenerateToken(user),
            FullName = $"{user.FirstName} {user.LastName}",
            Email = user.Email,
            Role = user.Role!.Name
        };
    }
}