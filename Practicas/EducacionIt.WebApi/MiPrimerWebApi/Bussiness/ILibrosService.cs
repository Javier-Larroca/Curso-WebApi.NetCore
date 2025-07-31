using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.Bussiness
{
    public interface ILibrosService
    {
        Task<IEnumerable<Libro>> GetLibros(int limit, int page);
        Task<Libro?> GetLibro(int id);
        Task<Libro> CreateLibro(Libro libro);
        Task UpdateLibro(int id, Libro libro);
        Task DeleteLibro(int id);
    }
}
