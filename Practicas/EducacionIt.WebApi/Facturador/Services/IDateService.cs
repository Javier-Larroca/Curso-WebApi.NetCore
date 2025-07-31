
namespace Facturador.Services
{
    public interface IDateService
    {
        Task<bool> IsFechaMayorAHoy(DateOnly date);
    }
}