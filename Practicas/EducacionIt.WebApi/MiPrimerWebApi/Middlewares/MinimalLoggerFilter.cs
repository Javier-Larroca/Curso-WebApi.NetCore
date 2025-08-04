
namespace MiPrimerWebApi.Middlewares
{
    public class MinimalLoggerFilter(ILogger<MinimalLoggerFilter> logger) : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            logger.LogInformation($"Mininal pasando por {context.HttpContext.Request.Path}");
            await next(context);
            logger.LogInformation($"Mininal pasó por {context.HttpContext.Request.Path}");
            return context.HttpContext.Response;
        }
    }
}
