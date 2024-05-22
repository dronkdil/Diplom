namespace Backend.Core.Interfaces.MailSender;

public interface IMailSender
{
    public void SendConfirmationCode(string email, int confirmationCode);
}