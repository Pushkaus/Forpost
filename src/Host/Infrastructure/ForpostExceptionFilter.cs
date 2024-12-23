using Forpost.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Forpost.Host.Infrastructure;

internal sealed class ForpostExceptionFilter : IExceptionFilter
{
    private ExceptionContext _exceptionContext = null!;

    public void OnException(ExceptionContext context)
    {
        _exceptionContext = context;

        var problemDetailsFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();

        if (context.Exception is ForpostExceptionBase exception)
        {
            HandlePredictableException(context, problemDetailsFactory, exception);
        }
        else
        {
            HandleUnpredictableException(context, problemDetailsFactory, context.Exception);
        }
    }

    private void HandlePredictableException(ExceptionContext context, ProblemDetailsFactory problemDetailsFactory,
        ForpostExceptionBase exception)
    {
        var problemDetails = problemDetailsFactory.CreateProblemDetails(
            context.HttpContext,
            StatusCodes.Status422UnprocessableEntity,
            exception.GetType().Name,
            exception.ErrorCode,
            exception.Message,
            instance: context.HttpContext.Request.Path);

        switch (exception)
        {
            case EntityNotFoundException _:
                SetProblemDetailsResponse(problemDetails, StatusCodes.Status404NotFound);
                break;
            case ValidationException _:
                SetProblemDetailsResponse(problemDetails, StatusCodes.Status400BadRequest);
                break;
        }
    }

    private void HandleUnpredictableException(ExceptionContext context, ProblemDetailsFactory problemDetailsFactory, Exception exception)
    {
        var problemDetails = problemDetailsFactory.CreateProblemDetails(
            context.HttpContext,
            StatusCodes.Status422UnprocessableEntity,
            title: "Непредвиденная ошибка",
            type: exception.GetType().Name,
            exception.Message,
            instance: context.Exception.StackTrace);

        SetProblemDetailsResponse(problemDetails);
    }

    private void SetProblemDetailsResponse(ProblemDetails problemDetails, int? statusCode = null)
    {
        var overridenStatusCode = statusCode ?? StatusCodes.Status422UnprocessableEntity;
        problemDetails.Status = overridenStatusCode;
        _exceptionContext.ExceptionHandled = true;

        _exceptionContext.HttpContext.Response.StatusCode = overridenStatusCode;
        _exceptionContext.Result = new ObjectResult(problemDetails)
        {
            StatusCode = overridenStatusCode
        };
    }
}