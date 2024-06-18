using Backend.Core.Futures.Notification.DTOs.Requests.Base;
using Backend.Domain.Entities.Enums;

namespace Backend.Core.Futures.Notification.DTOs.Requests;

public class StudentFinishedCourseDto : SendNotificationDto
{
    public StudentFinishedCourseDto(string courseName)
    {
        Title = $"Ви завершили курс {courseName}";
        Description = $"Вітаємо з завершенням курсу, ви можете отримати сертифікат на сторінці сертифікатів під назвою {courseName}";
        NotificationType = NotificationTypes.REG_STUD;
    }
}