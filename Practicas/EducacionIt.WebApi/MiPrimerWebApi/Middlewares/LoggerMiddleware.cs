
namespace MiPrimerWebApi.Middlewares
{
    public class LoggerMiddleware(ILogger<LoggerMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //context.Response.WriteAsJsonAsync("""{"error": true}""");
            
            logger.LogInformation($"Request iniciado en {context.Request.Path}");

            await next(context);

            logger.LogInformation($"Reques finalizada en {context.Request.Path}");
        }
    }
}
