﻿using System.Collections;
using Backend.Core.Futures.Users.Teachers.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Teachers;

public interface ITeacherService
{
    Task<Response> CreateAsync(CreateTeacherDto dto);
    Task<Response<IEnumerable<TeacherShortCourseDto>>> GetCoursesAsync(int userId);
    Task<Response> RemoveAsync(RemoveTeacherDto dto);
    Task<Response<IEnumerable<TeacherInformationDto>>> GetAllTeachersAsync();
}