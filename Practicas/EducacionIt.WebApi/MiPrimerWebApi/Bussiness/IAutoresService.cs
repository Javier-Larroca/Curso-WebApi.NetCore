using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.Bussiness
{
    public interface IAutoresService
    {
        Task<IEnumerable<Autor>> GetAutores(int limit, int page);
        Task<Autor?> GetAutor(int id);
        Task<Autor> CreateAutor(Autor autor);
        Task UpdateAutor(int id, Autor autor);
        Task DeleteAutor(int id);
    }
}