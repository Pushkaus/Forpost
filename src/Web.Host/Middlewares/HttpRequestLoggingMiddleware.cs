using Forpost.Common.Utils;

namespace Forpost.Web.Host.Middlewares;

internal sealed class HttpRequestLoggingMiddleware
{
    private readonly IIdentityProvider _identityProvider;
    private readonly ILogger<HttpRequestLoggingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public HttpRequestLoggingMiddleware(RequestDelegate next,
        ILogger<HttpRequestLoggingMiddleware> logger,
        IIdentityProvider identityProvider)
    {
        _next = next;
        _logger = logger;
        _identityProvider = identityProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userId = _identityProvider.GetUserId().ToString();
        var displayId = string.IsNullOrEmpty(userId) ? "Anonymous" : userId;
        
        _logger.LogInformation("Incoming HTTP request: {Method} {Path}, User ID: {UserId}",
            context.Request.Method, context.Request.Path, displayId);

        await _next(context);

        _logger.LogInformation("Outgoing HTTP response: {StatusCode}, User ID: {UserId}",
            context.Response.StatusCode, displayId);
    }
}

internal static class HttpRequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseHttpRequestLoggingWithEmployeeId(this IApplicationBuilder builder) => 
        builder.UseMiddleware<HttpRequestLoggingMiddleware>();
}