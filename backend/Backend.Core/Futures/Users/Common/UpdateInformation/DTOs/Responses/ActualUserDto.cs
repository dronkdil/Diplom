namespace Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Responses;

public class ActualUserDto
{
    public string? AvatarUrl { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DisplayName => FirstName + ' ' + LastName;
}