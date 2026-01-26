using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next,
            ILogger<GlobalExceptionHandlerMiddleware> logger)
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
            catch (Exception ex)
            {
                var traceId = Guid.NewGuid().ToString();
                context.Response.Headers["trace-id"] = traceId;
                _logger.LogError(
                     ex,
                     "Error no controlado. TraceId: {TraceId}. Path: {Path}",
                     traceId,
                     context.Request.Path
                 );
                var (statuscode, title) = MapExceptionToResponse(ex);
                var problem = new ProblemDetails
                {
                    Status = statuscode,
                    Title = title,
                    Detail = ex.Message,
                    Instance = context.Request.Path
                };
               
                problem.Extensions["traceId"] = traceId;

                await context.Response.WriteAsJsonAsync(problem);
            }
        }
        private (int, string) MapExceptionToResponse(Exception ex)
        {
            return ex switch
            {
                UnauthorizedAccessException =>
                (StatusCodes.Status401Unauthorized, "No autorizado"),
                KeyNotFoundException => (StatusCodes.Status404NotFound, "No encontrado"),
                ArgumentException => (StatusCodes.Status400BadRequest, "Solicitud invalida"),
                _ =>
               (StatusCodes.Status500InternalServerError, "Error interno del servidor")
            };
        }
    }
}
