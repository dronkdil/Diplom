using System.Reflection;
using Backend.Core.Futures.Authentication;
using Backend.Core.Futures.Authentication.Validators;
using Backend.Core.Futures.MaterialsForStudy.Courses;
using Backend.Core.Futures.MaterialsForStudy.Homeworks;
using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs;
using Backend.Core.Futures.MaterialsForStudy.Lessons;
using Backend.Core.Futures.MaterialsForStudy.Modules;
using Backend.Core.Futures.Notification;
using Backend.Core.Futures.Users.Common.UpdateInformation;
using Backend.Core.Futures.Users.Students;
using Backend.Core.Futures.Users.Students.UpdateInformation;
using Backend.Core.Futures.Users.Teachers;
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
        services.AddTransient<IUpdateUserDataService, UpdateUserDataService>();
        services.AddTransient<IUpdateStudentDataService, UpdateStudentDataService>();
        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<IModuleService, ModuleService>();
        services.AddTransient<ILessonService, LessonService>();
        services.AddTransient<IHomeworkService, HomeworkService>();
        services.AddTransient<INotificationService, NotificationService>();
        return services;
    }
}