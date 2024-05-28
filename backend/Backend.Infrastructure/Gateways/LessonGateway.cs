using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Gateways;

public class LessonGateway : ILessonGateway
{
    private readonly DataContext _dataContext;

    public LessonGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Lesson?> GetByIdWithLessonsOfModuleAsync(int id)
    {
        return await _dataContext.Lessons
            .Include(o => o.Module)
            .ThenInclude(o => o.Lessons)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(Lesson lesson)
    {
        _dataContext.Lessons.Add(lesson);
        await _dataContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        _dataContext.Lessons.Remove(new Lesson { Id = id });
        await _dataContext.SaveChangesAsync();
    }

    public async Task<Lesson?> UpdateAsync(int id, Action<Lesson> configure)
    {
        var lesson = await _dataContext.Lessons.FirstOrDefaultAsync(o => o.Id == id);
        if (lesson == null)
            return null;

        configure(lesson);
        await _dataContext.SaveChangesAsync();
        return lesson;
    }
}