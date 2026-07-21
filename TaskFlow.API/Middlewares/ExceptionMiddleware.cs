using FluentValidation;
using System.Net;
using System.Text.Json;

using TaskFlow.Domain.Common.Exceptions;


namespace TaskFlow.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new
            {
                Success = false,
                Errors = ex.Errors.Select(e => e.ErrorMessage)
            });

            await context.Response.WriteAsync(result);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new
            {
                Success = false,
                Message = ex.Message
            });

            await context.Response.WriteAsync(result);

        }
    }
}