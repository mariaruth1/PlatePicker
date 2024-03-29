﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using models.exceptions;

namespace api.exceptions;

public class ExceptionFilter : IAsyncExceptionFilter
{
    private readonly IHostEnvironment _hostEnvironment;
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(IHostEnvironment hostEnvironment, ILogger<ExceptionFilter> logger)
    {
        _hostEnvironment = hostEnvironment;
        _logger = logger;
    }
    
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        context.ExceptionHandled = true;
        var exception = context.Exception;

        string errorCode;
        int statusCode;
        string errorMessage;

        if (exception is AppException appException)
        {
            switch (appException)
            {
                case NotFoundException notFoundException:
                    errorCode = "NotFound";
                    statusCode = StatusCodes.Status404NotFound;
                    errorMessage = notFoundException.Message;
                    break;
                //TODO: Add more cases here

                // This should never happen in production
                default:
                    errorCode = "AppExceptionNotHandled";
                    statusCode = StatusCodes.Status500InternalServerError;
                    errorMessage = "AppException not handled in exception filter";
                    break;
            }
        } else
        {
            // Unhandled error
            _logger.LogError(exception, "Unhandled exception");

            errorCode = string.Empty;
            statusCode = StatusCodes.Status500InternalServerError;
            errorMessage = exception.Message;

            if (_hostEnvironment.IsDevelopment() || _hostEnvironment.IsStaging())
            {
                errorMessage = exception.Message;
            }
        }

        context.HttpContext.Response.StatusCode = statusCode;
        await context.HttpContext.Response.WriteAsJsonAsync(
            new ProblemDetails()
            {
                Status = statusCode,
                Detail = errorMessage,
                Title = errorCode
            });
    }
}