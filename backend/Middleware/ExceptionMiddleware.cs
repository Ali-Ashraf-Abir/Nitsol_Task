using System.Net;
using System.Text.Json;
using backend.Exceptions;

namespace backend.Middleware;

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
        catch (BadRequestException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            await context.Response.WriteAsJsonAsync(new
            {
                message = ex.Message
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            context.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsJsonAsync(new
            {
                message = "Something went wrong"
            });
        }
    }
}