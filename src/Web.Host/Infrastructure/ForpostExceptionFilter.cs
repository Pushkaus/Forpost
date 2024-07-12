using Forpost.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Forpost.Web.Host.Infrastructure;

internal sealed class ForpostExceptionFilter : IExceptionFilter
{
    private ExceptionContext _exceptionContext = null!;


    public void OnException(ExceptionContext context)
    {
        _exceptionContext = context;
        var problemDetailsFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();

        if (context.Exception is ForpostExceptionBase exception)
        {
            var problemDetails = problemDetailsFactory.CreateProblemDetails(
                context.HttpContext,
                StatusCodes.Status422UnprocessableEntity,
                title: exception.ShortDescription,
                type: exception.ErrorCode,
                detail: exception.Message);

            switch (exception)
            {
                case EntityNotFoundException _ : SetStatusCode(problemDetails,StatusCodes.Status404NotFound);
                    break;
                default:
                    break;
            }
        }

        context.ExceptionHandled = true;
    }

    private void SetStatusCode(ProblemDetails problemDetails, int? statusCode = null)
    {
        var overridenStatusCode = statusCode ?? StatusCodes.Status422UnprocessableEntity;
        problemDetails.Status = overridenStatusCode;

        _exceptionContext.HttpContext.Response.StatusCode = overridenStatusCode;
        _exceptionContext.Result = new ObjectResult(problemDetails)
        {
            StatusCode = overridenStatusCode
        };
    }
}