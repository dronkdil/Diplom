using Backend.Domain.Entities.Enums;

namespace Backend.Core.Interfaces.JwtTokenFactory;

public interface IJwtTokenFactory
{
    public JwtTokens CreateTokens(int id, string role);
    public bool Validate(string accessToken, out int userId);
}