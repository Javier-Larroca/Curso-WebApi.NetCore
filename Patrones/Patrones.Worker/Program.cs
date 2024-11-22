using Patrones.Worker;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<Worker>();
        builder.Services.AddSingleton<IServicioSingleton, ServicioSingleton>();
        builder.Services.AddScoped<IServicioScoped, ServicioScoped>();
        builder.Services.AddTransient<IServicioTransient, ServicioTransient>();

        var host = builder.Build();
        //host.Run();

        EjemploLifetime(host.Services, "Lifetime 1");
        EjemploLifetime(host.Services, "Lifetime 2");

    }

    static void EjemploLifetime(IServiceProvider provider, string lifetime)
    {
        using var scope = provider.CreateScope();
        Console.WriteLine($"Corriendo el lifetime {lifetime}");

        var servicioSingleton = scope.ServiceProvider.GetRequiredService<IServicioSingleton>();
        servicioSingleton.DoWork();

        var servicioScoped = scope.ServiceProvider.GetRequiredService<IServicioScoped>();
        servicioScoped.DoWork();

        var servicioTransient = scope.ServiceProvider.GetRequiredService<IServicioTransient>();
        servicioTransient.DoWork();

        var servicioSingleton2 = scope.ServiceProvider.GetRequiredService<IServicioSingleton>();
        servicioSingleton2.DoWork();

        var servicioScoped2 = scope.ServiceProvider.GetRequiredService<IServicioScoped>();
        servicioScoped2.DoWork();

        var servicioTransient2 = scope.ServiceProvider.GetRequiredService<IServicioTransient>();
        servicioTransient2.DoWork();
    }
} 