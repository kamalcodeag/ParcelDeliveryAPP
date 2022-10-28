using Identity.Logic.Exceptions;
using Newtonsoft.Json;

namespace Identity.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Request started");
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception, int statusCode = 500, string contentType = "application/json")
        {
            var result = JsonConvert.SerializeObject(new BaseException
            {
                StatusCode = statusCode,
                Message = exception.Message
            });

            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
