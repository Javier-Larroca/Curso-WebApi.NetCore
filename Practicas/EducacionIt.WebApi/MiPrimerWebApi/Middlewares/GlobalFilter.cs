using Microsoft.AspNetCore.Mvc.Filters;

namespace MiPrimerWebApi.Middlewares
{
    public class GlobalFilter(ILogger<GlobalFilter> logger) : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation($"Accion global ejecutada");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation($"Accion global ejecutandose");
        }
    }
}
