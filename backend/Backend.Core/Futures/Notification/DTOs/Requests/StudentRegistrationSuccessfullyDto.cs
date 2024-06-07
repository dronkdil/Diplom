using Backend.Core.Futures.Notification.DTOs.Requests.Base;

namespace Backend.Core.Futures.Notification.DTOs.Requests;

public class StudentRegistrationSuccessfullyDto : SendNotificationDto
{
    public StudentRegistrationSuccessfullyDto()
    {
        Title = "Реєстрація успішна";
        Description = "Для перегляду курсів перейдіть на сторінку, натиснувши на логотип зліва-зверху";
    }
}