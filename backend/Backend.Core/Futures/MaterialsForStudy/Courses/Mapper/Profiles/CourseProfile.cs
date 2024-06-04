using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;
using Backend.Core.Futures.MaterialsForStudy.Courses.Mapper.Actions;
using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.Mapper.Profiles;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, ActualCourseDto>();
        CreateMap<Course, ShortCourseDto>();
        CreateMap<Course, CoursePageDto>()
            .AfterMap((src, dest, context) => dest.Modules = context.Mapper.Map<IEnumerable<ModuleDto>>(src.Modules));
        CreateMap<Module, ModuleDto>()
            .AfterMap((src, dest, context) => dest.Lessons = context.Mapper.Map<IEnumerable<CourseLessonDto>>(src.Lessons));
        CreateMap<Lesson, CourseLessonDto>()
            .AfterMap<IsCompletedLessonAction>();
        CreateMap<Teacher, TeacherDto>();
    }
}