using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Enums;
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

    public async Task<IEnumerable<Course>?> GetCoursesAsync(int id)
    {
        var teacher = await _dataContext.Teachers
            .Include(o => o.Courses)
            .ThenInclude(o => o.Students)
            .FirstOrDefaultAsync(o => o.Id == id);
        return teacher?.Courses;
    }
    
    public async Task<bool> AddAsync(Teacher user)
    {
        try
        {
            _dataContext.Teachers.Add(user);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            // TODO: Add a logger
            return false;
        }
    }

    public async Task<bool> RemoveAsync(int id)
    {
        try
        {
            _dataContext.Teachers.Remove(new Teacher { Id = id });
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            // TODO: Add a logger
            return false;
        }
    }

    public async Task<IEnumerable<Teacher>> GetAllTeachers()
    {
        return await _dataContext.Teachers.ToListAsync();
    }
}