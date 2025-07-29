using System.Text.Json;

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
            int statusCode = 500;
            string message;
            if (ex.InnerException != null)
            {
                message  = ex.InnerException.Message;
            } else
            {
                message = ex.Message;
            }

            /*if (ex is AppException appEx)
            {
                statusCode = appEx.StatusCode;
                message = appEx.Message;
            }*/

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
