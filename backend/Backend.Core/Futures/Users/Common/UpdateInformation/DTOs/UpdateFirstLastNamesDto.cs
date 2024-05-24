using System.Reflection.Metadata.Ecma335;

namespace Backend.Core.Futures.Users.Common.UpdateInformation.DTOs;

public class UpdateFirstLastNamesDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}