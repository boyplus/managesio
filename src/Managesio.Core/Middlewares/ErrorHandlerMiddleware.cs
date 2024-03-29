using System.Net;
using System.Text.Json;
using Managesio.Core.Exceptions;
using SendGrid.Helpers.Errors.Model;

namespace Managesio.Core.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            switch (error)
            {
                case AppException e:
                    // Custom Application Error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    // Not Found Error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnauthorizedException e:
                    // Unauthorized error
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                default:
                    _logger.LogError(error, error.Message);
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new {messge = error.Message});
            await response.WriteAsync(result);
        }
    }
}