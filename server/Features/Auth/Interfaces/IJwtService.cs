using server.Entities;

namespace server.Features.Auth.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}