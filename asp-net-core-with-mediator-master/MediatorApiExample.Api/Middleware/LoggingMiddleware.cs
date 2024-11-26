using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MediatorApiExample.Api.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Request URL: {context.Request.Path}");
        await _next(context); // Передача запиту наступному Middleware
        Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
    }
}