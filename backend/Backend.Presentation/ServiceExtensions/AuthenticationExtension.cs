using System.Text;
using Backend.Domain.Entities.Enums;
using Backend.Presentation.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Presentation.ServiceExtensions;

public static class AuthenticationExtension
{
    public static void AddConfiguredAuthentication(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy(AuthorizationPolicies.Student, new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Roles.Student.ToString())
                .Build());
            
            options.AddPolicy(AuthorizationPolicies.Teacher, new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Roles.Teacher.ToString())
                .Build());
            
            options.AddPolicy(AuthorizationPolicies.Administrator, new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Roles.Administrator.ToString())
                .Build());
        });
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
            options =>  options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration.GetSection("JWT:Issuer").Value,
            ValidateAudience = true,
            ValidAudience = configuration.GetSection("JWT:Audience").Value,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("JWT:Key").Value!
            )),
            ValidateIssuerSigningKey = true,
        });
    }
}