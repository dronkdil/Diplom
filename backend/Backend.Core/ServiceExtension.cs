using System.Reflection;
using Backend.Core.Futures.Authentication;
using Backend.Core.Futures.Authentication.Validators;
using Backend.Core.Futures.MaterialsForStudy.Courses;
using Backend.Core.Futures.Teachers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Core;

public static class ServiceExtension
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper((serviceProvider, options) =>
        {
            options.ConstructServicesUsing(serviceProvider.GetRequiredService);
        }, Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblyContaining<LoginValidator>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<ITeacherService, TeacherService>();
        services.AddTransient<ICourseService, CourseService>();
        return services;
    }
}