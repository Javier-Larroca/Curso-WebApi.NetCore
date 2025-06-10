namespace MiPrimerWebApi
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public static class Test
    {
        public static void Test1()
        {
            var forescast = new WeatherForecast();
            forescast.ToKelvin();
            //WeatherForescastExtensionMethods.ToKelvin(forescast);
        }
    }

    public static class WeatherForescastExtensionMethods
    {
        public static double ToKelvin(this WeatherForecast forecast)
        {
            return forecast.TemperatureC + 273.15;
        }
    }
}
