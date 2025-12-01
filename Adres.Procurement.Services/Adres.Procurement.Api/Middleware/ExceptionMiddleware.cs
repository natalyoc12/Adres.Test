using System.Net;
using Adres.Procurement.Api.Response;
using Adres.Procurement.Application.Excepctions;

namespace Adres.Procurement.Api.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode code;
        string message;
        object? data = null;

        switch (exception)
        {
            case FluentValidation.ValidationException fv:
                code = HttpStatusCode.BadRequest;
                message = "Body validation failed.";
                data = fv.Errors;
                break;

            case ValidationException ve:
                code = HttpStatusCode.BadRequest;
                message = "Body validation failed.";
                data = ve.Errors;
                break;

            case NotFoundException nf:
                code = HttpStatusCode.NotFound;
                message = nf.Message;
                break;

            case ConflictException ce:
                code = HttpStatusCode.Conflict;
                message = ce.Message;
                break;

            default:
                code = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        var response = new ApiResponse<object>(code, message, data);
        return context.Response.WriteAsJsonAsync(response);
    }
}
