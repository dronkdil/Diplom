﻿namespace Backend.Core.Futures.Users.Teachers.DTOs;

public class TeacherShortCourseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int StudentCount { get; set; }
}