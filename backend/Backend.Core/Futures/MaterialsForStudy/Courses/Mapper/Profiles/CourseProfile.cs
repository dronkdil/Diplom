﻿using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.Mapper.Profiles;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<Module, ModuleDto>();
        CreateMap<Lesson, ShortLessonDto>();
    }
}