using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Core.Interfaces.JwtTokenFactory;
using Backend.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Infrastructure.Implementations.JwtTokenFactory;

public class JwtTokenFactory : IJwtTokenFactory
{
    private readonly JwtTokenOptions _options;

    public JwtTokenFactory(IOptions<JwtTokenOptions> options)
    {
        _options = options.Value;
    }
    
    public JwtTokens CreateTokens(int id, string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Role, role)
        };

        return new JwtTokens
        {
            AccessToken = Create(
                claims, 
                DateTime.UtcNow.Add(TimeSpan.FromMinutes(_options.AccessExpiresMinutes))
            ),
            RefreshToken = Create(
                claims, 
                DateTime.UtcNow.Add(TimeSpan.FromDays(_options.RefreshExpiresDays))
            )
        };
    }

    public bool Validate(string token, out int userId)
    {
        try
        {
            var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, CreateValidationOptions(), out _);
            var claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;
            var claim = claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier);
            userId = int.Parse(claim!.Value);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            userId = 0;
            return false;
        }
    }

    public TokenValidationParameters CreateValidationOptions()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _options.Issuer,
            ValidateAudience = true,
            ValidAudience = _options.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _options.Key
            )),
            ValidateIssuerSigningKey = true,
        };
    }
   
   private string Create(IEnumerable<Claim> claims, DateTime expires)
   {
       return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
           issuer: _options.Issuer,
           audience: _options.Audience,
           claims: claims,
           expires: expires,
           signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
               _options.Key
           )), SecurityAlgorithms.HmacSha256)
       ));
   }
}