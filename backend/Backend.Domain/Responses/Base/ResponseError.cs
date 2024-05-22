namespace Backend.Domain.Responses.Base;

public class ResponseError
{
    public string PropertyName { get; set; } = null!;
    public string ErrorMessage { get; set; } = null!;
    public object ActualValue { get; set; } = null!;
}