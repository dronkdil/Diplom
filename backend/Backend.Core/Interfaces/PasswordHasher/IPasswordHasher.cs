namespace Backend.Core.Interfaces.PasswordHasher;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Compare(string hash, string password);
}