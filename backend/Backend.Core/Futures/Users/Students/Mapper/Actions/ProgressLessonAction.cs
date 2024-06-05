using AutoMapper;
using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Core.UserContext;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Users.Students.Mapper.Actions;

public class ProgressLessonAction : IMappingAction<Course, StudentCourseDto>
{
    private readonly IUserContext _userContext;
    
    public ProgressLessonAction(IUserContext userContext)
    {
        _userContext = userContext;
    }

    public void Process(Course source, StudentCourseDto destination, ResolutionContext context)
    {
        var allLessons = source.Modules.SelectMany(o => o.Lessons).ToList();
        var allLessonsCount = allLessons.Count;
        var completedLessonsCount = allLessons.Count(o => IsLessonCompleted(o));

        if (allLessonsCount == 0 || completedLessonsCount == 0)
            destination.Progress = 0;
        else
            destination.Progress = (int)(((double)completedLessonsCount / (double)allLessonsCount) * (double)100);
    }

    private bool IsLessonCompleted(Lesson lesson)
    {
        if (lesson.HaveHomework)
        {
            var homeworkCompleted = lesson.Homeworks.Any(o => o.StudentId == _userContext.UserId && o.Appraisal != null);
            return homeworkCompleted;
        }
        else
        {
            var lessonViewed = lesson.ViewedLessons.Any(o => o.StudentId == _userContext.UserId && o.LessonId == lesson.Id);
            return lessonViewed;
        }
    }
}