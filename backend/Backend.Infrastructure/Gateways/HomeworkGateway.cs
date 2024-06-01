using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Gateways;

public class HomeworkGateway : IHomeworkGateway
{
    private readonly DataContext _dataContext;

    public HomeworkGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddOrUpdateAsync(Homework homework)
    {
        if (await _dataContext.Homeworks.AnyAsync(o => o.Id == homework.Id))
        {
            homework.Appraisal = null;
            homework.CommentFromTeacher = null;
            homework.Сompleted = true;
            _dataContext.Homeworks.Update(homework);
        }
        else
        {
            homework.Сompleted = true;
            _dataContext.Homeworks.Add(homework);
        }
        await _dataContext.SaveChangesAsync();
    }

    public async Task CancelSendingAsync(int id)
    {
        var homework = await _dataContext.Homeworks.FirstAsync(o => o.Id == id);
        homework.Сompleted = false;
        await _dataContext.SaveChangesAsync();
    }

    public async Task EvaluateAsync(int id, int? appraisal, string? comment)
    {
        var homework = await _dataContext.Homeworks.FirstAsync(o => o.Id == id);
        homework.Appraisal = appraisal;
        homework.CommentFromTeacher = comment;
        await _dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Homework>> GetByLessonIdWithStudentAsync(int lessonId)
    {
        return await _dataContext.Homeworks
            .Include(o => o.Student)
            .Where(o => o.LessonId == lessonId 
                        && o.Сompleted == true 
                        && o.Appraisal == null 
                        && o.CommentFromTeacher == null)
            .ToListAsync();
    }

    public async Task<Homework?> GetByStudentIdAsync(int studentId)
    {
        return await _dataContext.Homeworks.FirstOrDefaultAsync(o => o.StudentId == studentId);
    }
}