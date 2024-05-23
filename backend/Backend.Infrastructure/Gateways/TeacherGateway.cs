using Backend.Core.Futures.Teacher;
using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Gateways;

public class TeacherGateway : ITeacherGateway
{
    private readonly DataContext _dataContext;

    public TeacherGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Course>?> GetCoursesAsync(int userId)
    {
        var teacher = await _dataContext.TeacherAdditionalData
            .Include(o => o.Courses)
            .ThenInclude(o => o.Students)
            .FirstOrDefaultAsync(o => o.UserId == userId);
        return teacher?.Courses;
    }
}