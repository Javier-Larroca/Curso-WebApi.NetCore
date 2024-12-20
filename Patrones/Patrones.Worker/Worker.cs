namespace Patrones.Worker
{
    public class Worker(ILogger<Worker> logger,
        IServicioSingleton servicioSingletone
        ) : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //if (_logger.IsEnabled(LogLevel.Information))
                //{
                //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //}

                servicioSingletone.DoWork();

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
