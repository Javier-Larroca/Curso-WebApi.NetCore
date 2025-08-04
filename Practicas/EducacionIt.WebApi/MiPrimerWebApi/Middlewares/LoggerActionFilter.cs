using Microsoft.AspNetCore.Mvc.Filters;

namespace MiPrimerWebApi.Middlewares
{
    public class LoggerActionFilter(ILogger<LoggerActionFilter> logger) : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation($"Accion ejecutada en {context.HttpContext.Request.Path}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation($"Accion ejecutandose en {context.HttpContext.Request.Path}");
        }
    }
}
