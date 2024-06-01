namespace Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Responses;

public class CompletedHomeworkDto
{
    public int Id { get; set; }
    public string Answer { get; set; } = null!;
    public string StudentDisplayName { get; set; } = null!;
}