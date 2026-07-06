using System.Net;
using System.Text.Json;

namespace GlobalECommerce.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (KeyNotFoundException ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.NotFound,
                ex);
        }
        catch (ArgumentException ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.BadRequest,
                ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.InternalServerError,
                ex);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        HttpStatusCode statusCode,
        Exception exception)
    {
        _logger.LogError(
            exception,
            "Unhandled Exception. TraceId: {TraceId}",
            context.TraceIdentifier);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new ErrorResponse
        {
            TraceId = context.TraceIdentifier,
            StatusCode = (int)statusCode,
            Message = statusCode == HttpStatusCode.InternalServerError
        ? "An unexpected error occurred. Please try again later."
        : exception.Message
        };

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}

public class ErrorResponse
{
    public int StatusCode { get; set; }

    public string Message { get; set; } = string.Empty;

    public string TraceId { get; set; } = string.Empty;
}