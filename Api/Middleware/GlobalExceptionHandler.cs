using System.Net;
using System.Text.Json;

namespace Api.Middleware
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError("Timestamp:{timestamp}, ErrorMessage:{exceptionMessage}, StackTrace: {stacktrace}", DateTime.Now, exception.Message, exception.StackTrace);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = new
                {
                    ErrorMessage = "An error occurred. Please try again later.",
                    ErrorCode = 500
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }
        }
    }
}