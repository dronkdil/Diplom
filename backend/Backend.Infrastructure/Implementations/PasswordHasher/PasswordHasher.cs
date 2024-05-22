using Backend.Core.Interfaces.PasswordHasher;

namespace Backend.Infrastructure.Implementations.PasswordHasher;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return password + "_hashed";
    }

    public bool Compare(string hash, string password)
    {
        return hash == Hash(password);
    }
}