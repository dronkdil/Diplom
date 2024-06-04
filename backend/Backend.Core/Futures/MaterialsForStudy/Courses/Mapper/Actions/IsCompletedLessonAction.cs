using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;
using Backend.Core.UserContext;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.Mapper.Actions;

public class IsCompletedLessonAction : IMappingAction<Lesson, CourseLessonDto>
{
    private readonly IUserContext _userContext;
    
    public IsCompletedLessonAction(IUserContext userContext)
    {
        _userContext = userContext;
    }

    public void Process(Lesson source, CourseLessonDto destination, ResolutionContext context)
    {
        if (source.HaveHomework)
        {
            var homeworkCompleted = source.Homeworks.Any(o => o.StudentId == _userContext.UserId && o.Appraisal != null);
            destination.Completed = homeworkCompleted;
        }
        else
        {
            var lessonViewed = source.ViewedLessons.Any(o => o.StudentId == _userContext.UserId && o.LessonId == source.Id);
            destination.Completed = lessonViewed;
        }
    }
}