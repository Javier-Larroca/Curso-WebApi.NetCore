namespace Patrones.Worker
{
    public class Worker(ILogger<Worker> logger,
        IServicioSingleton servicioSingleton) : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //if (logger.IsEnabled(LogLevel.Information))
                //{
                //    logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //}

                servicioSingleton.DoWork();

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
