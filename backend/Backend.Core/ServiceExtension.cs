using System.Reflection;
using Backend.Core.Futures.Authentication;
using Backend.Core.Futures.Authentication.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Core;

public static class ServiceExtension
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblyContaining<LoginValidator>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        return services;
    }
}