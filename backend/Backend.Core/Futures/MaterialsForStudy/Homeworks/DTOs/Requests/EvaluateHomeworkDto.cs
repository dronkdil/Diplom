namespace Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Requests;

public class EvaluateHomeworkDto
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public int? Appraisal { get; set; }
}