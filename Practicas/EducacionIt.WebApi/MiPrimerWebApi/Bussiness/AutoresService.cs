using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi.Bussiness.BussinessExceptions;
using MiPrimerWebApi.DataAccess.Contexto;
using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.Bussiness
{
    public class AutoresService(BibliotecaDbContext db) : IAutoresService
    {

        public async Task<IEnumerable<Autor>> GetAutores()
        {
            return await db.Autores.ToListAsync();
        }

        public async Task<Autor?> GetAutor(int id)
        {
            return await db.Autores
                .Include(a => a.Libros)
                .ThenInclude(l => l.Generos)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        private Task<bool> AutorExists(int id)
        {
            return db.Autores.AnyAsync(e => e.Id == id);
        }

        public async Task UpdateAutor(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                throw new DatosInvalidosException("El id no el mismo que el id del body.");
            }

            db.Entry(autor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AutorExists(id))
                {
                    throw new AutorNoExisteException(id);
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Autor> CreateAutor(Autor autor)
        {
            db.Autores.Add(autor);
            await db.SaveChangesAsync();

            return autor;
        }

        public async Task DeleteAutor(int id)
        {
            var autor = await db.Autores.FindAsync(id);
            if (autor == null)
            {
                throw new AutorNoExisteException(id);
            }

            db.Autores.Remove(autor);
            await db.SaveChangesAsync();
        }
    }
}
