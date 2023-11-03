using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyBuberDinner.Api.Filters;


public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        context.Result = new ObjectResult(new {StatusCode = 500, error = "an error occured while processing your request."});

        context.ExceptionHandled = true;
    }
}