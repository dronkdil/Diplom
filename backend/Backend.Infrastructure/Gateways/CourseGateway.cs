using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.Infrastructure.Gateways;

public class CourseGateway : ICourseGateway
{
    private readonly DataContext _dataContext;

    public CourseGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> AddAsync(Course course)
    {
        try
        {
            _dataContext.Add(course);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> RemoveAsync(int id)
    {
        try
        {
            _dataContext.Remove(new { Id = id });
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _dataContext.Courses
            .Include(o => o.Modules)
            .ThenInclude(o => o.Lessons)
            .ToListAsync();
    }
}