using Microsoft.Extensions.DependencyInjection;

namespace Backend.Core;

public static class ServiceExtension
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}