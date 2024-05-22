using FluentValidation.Results;

namespace Backend.Domain.Responses.Base;

public class Response<T> : Response
{
    public T? Value { get; set; }
}

public class Response
{
    public ResponseType Type { get; set; }
    public IEnumerable<ResponseError> Errors { get; set; } = null!;
    
    public static Response<T> Success<T>(T? value) => new()
    {
        Type = ResponseType.Successfully,
        Value = value,
    };

    public static Response<T> ValidationFailed<T>(IEnumerable<ValidationFailure> errors) => new()
    {
        Type = ResponseType.ValidationFailed,
        Value = default,
        Errors = errors.Select(o => new ResponseError
        {
            PropertyName = o.PropertyName,
            ErrorMessage = o.ErrorMessage,
            ActualValue = o.AttemptedValue
        })
    };

    public static Response<T> Failed<T>(string error) => new()
    {
        Type = ResponseType.Failed,
        Errors = new[] {new ResponseError
        {
            PropertyName = "All",
            ErrorMessage = error,
            ActualValue = "",
        }}
    };
}