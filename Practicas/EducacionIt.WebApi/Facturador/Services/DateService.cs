namespace Facturador.Services
{
    public class DateService : IDateService
    {
        public Task<bool> IsFechaMayorAHoy(DateOnly date)
        {
            if (date > DateOnly.FromDateTime(DateTime.Now))
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
