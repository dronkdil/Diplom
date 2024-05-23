using Backend.Core.Futures.Teachers;
using Backend.Core.Gateways;
using Backend.Core.Interfaces.JwtTokenFactory;
using Backend.Core.Interfaces.PasswordHasher;
using Backend.Domain.Options;
using Backend.Infrastructure.EF;
using Backend.Infrastructure.Gateways;
using Backend.Infrastructure.Implementations.JwtTokenFactory;
using Backend.Infrastructure.Implementations.PasswordHasher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<ConfigurationManager>();

        services.AddDbContext<DataContext>(o => o.UseSqlServer(configuration.GetConnectionString("Default")));
        services.Configure<JwtTokenOptions>(configuration.GetSection(JwtTokenOptions.Name));

        services.AddTransient<IJwtTokenFactory, JwtTokenFactory>();
        services.AddTransient<IPasswordHasher, PasswordHasher>();
        services.AddTransient<IUserGateway, CommonUserGateway>();
        services.AddTransient<ITeacherGateway, TeacherGateway>();
        services.AddTransient<IStudentGateway, StudentGateway>();
        services.AddTransient<ICourseGateway, CourseGateway>();
        return services;
    }
}