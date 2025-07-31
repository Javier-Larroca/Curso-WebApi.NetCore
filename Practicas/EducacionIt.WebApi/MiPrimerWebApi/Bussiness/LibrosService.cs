using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi.Bussiness.BussinessExceptions;
using MiPrimerWebApi.DataAccess.Contexto;
using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.Bussiness
{
    public class LibrosService(BibliotecaDbContext db) : ILibrosService
    {
        public async Task<IEnumerable<Libro>> GetLibros(int limit, int page)
        {
            return await db.Libros
                .AsNoTracking()
                .Include(a => a.Autor)
                .Include(g => g.Generos)
                .OrderBy(a => a.Id)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Libro?> GetLibro(int id)
        {
            return await db.Libros
                .AsNoTracking()
                .Include(a => a.Autor)
                .Include(g => g.Generos)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Libro> CreateLibro(Libro libro)
        {
            var autorExiste = await db.Autores
                //.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == libro.Autor!.Id);

            if (autorExiste == null)
            {
                throw new AutorNoExisteException(libro.Autor!.Id);
            }

            db.Entry(libro.Autor).State = EntityState.Unchanged;

            foreach (var genero in libro.Generos)
            {
                db.Entry(genero).State = EntityState.Unchanged;
            }

            //db.Entry(libro.Autor).State = EntityState.Unchanged;

            libro.Autor = autorExiste;

            db.Libros.Add(libro);
            await db.SaveChangesAsync();

            return libro;
        }

        public async Task UpdateLibro(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                throw new DatosInvalidosException("El id no el mismo que el id del body.");
            }

            var autorExiste = await db.Autores.FirstOrDefaultAsync(a => a.Id == libro.Autor!.Id);

            if (autorExiste == null)
            {
                throw new AutorNoExisteException(libro.Autor!.Id);
            }

            db.Entry(libro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LibroExists(id))
                {
                    throw new LibroNoExisteException(id);
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteLibro(int id)
        {
            var libro = await db.Libros.FindAsync(id);
            if (libro == null)
            {
                throw new LibroNoExisteException(id);
            }

            db.Libros.Remove(libro);
            await db.SaveChangesAsync();
        }

        private Task<bool> LibroExists(int id)
        {
            return db.Libros.AnyAsync(e => e.Id == id);
        }
    }
}
