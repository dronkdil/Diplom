using Backend.Domain.Responses.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Backend.Presentation.Filters;

public class ResponseFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var response = (context.Result as ObjectResult)?.Value as Response;
        if (response?.Type != ResponseType.Successfully)
        {
            context.Result = new ObjectResult(response)
            {
                StatusCode = 400
            };
        }
    }
}