using System.Text.Json;

using Shared.Common.Sources.Exceptions;

namespace Ecommerce.API.Middleware;

/// <summary>
/// <see cref="ExceptionHandlerMiddleware"/> exceptions handler code
/// </summary>
public sealed class ExceptionHandlerMiddleware
{
    #region Props & Ctor

    private readonly RequestDelegate _next;

    /// <summary>
    /// <see cref="ExceptionHandlerMiddleware"/> constructor
    /// </summary>
    /// <param name="next"></param>
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    #endregion
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await ExceptionHandler(context, ex).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Method to analize and set status code & message to client
    /// </summary>
    /// <param name="context"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    private Task ExceptionHandler(HttpContext context, Exception ex)
    {
        int statusCode = SetStatusCode(ex);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        bool canAddMessage = CanAddMessage(statusCode);
        if (!canAddMessage)
            return context.Response.WriteAsync(string.Empty);

        string result = JsonSerializer.Serialize(new
        {
            Message = SetMessage(statusCode, ex.Message)
        });
        return context.Response.WriteAsync(result);
    }

    /// <summary>
    /// Set <see cref="StatusCodes"/> based in <see cref="Exception"/> type
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    private int SetStatusCode(Exception ex) => ex switch
    {
        BadRequestException => StatusCodes.Status400BadRequest,
        NotFoundException => StatusCodes.Status404NotFound,
        UnauthException => StatusCodes.Status401Unauthorized,
        _ => StatusCodes.Status500InternalServerError
    };

    /// <summary>
    /// Set message based in <see cref="Exception"/> type
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    private string SetMessage(int statusCode, string message) => statusCode switch
    {
        StatusCodes.Status400BadRequest => message,
        StatusCodes.Status404NotFound => message,
        _ => string.Empty
    };

    /// <summary>
    /// Choose if return some message with status code, base in <see cref="Exception"/> type
    /// </summary>
    /// <param name="statusCode"></param>
    /// <returns></returns>
    private bool CanAddMessage(int statusCode) => statusCode switch
    {
        StatusCodes.Status400BadRequest => true,
        StatusCodes.Status404NotFound => true,
        _ => false
    };
}
