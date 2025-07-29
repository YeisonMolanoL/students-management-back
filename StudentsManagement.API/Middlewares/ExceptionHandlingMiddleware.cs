using System.Text.Json;
using StudentsManagement.StudentsManagement.Shared.Exceptions;

namespace StudentsManagement.StudentsManagement.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, $"[ERROR JSON] {ex.Message}");
            _logger.LogError(ex, $"[ERROR JSON CONTEXT] {context}");

            int statusCode;
            string message;

            if (ex is StudentsManagementException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                message = ex.Message;
            }
            else
            {
                statusCode = StatusCodes.Status500InternalServerError;
                message = ex.InnerException?.Message ?? ex.Message;
            }

            _logger.LogError(ex, $"[ERROR] {message}");

            var response = new
            {
                status = statusCode,
                message,
                exception = ex.GetType().Name,
                timestamp = DateTime.UtcNow
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
