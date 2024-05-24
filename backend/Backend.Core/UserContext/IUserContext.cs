namespace Backend.Core.UserContext;

public interface IUserContext
{
    bool IsAuthenticated { get; }
    int UserId { get; }
}