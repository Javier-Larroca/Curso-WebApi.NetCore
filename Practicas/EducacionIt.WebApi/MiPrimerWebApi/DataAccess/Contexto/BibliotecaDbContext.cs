using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.DataAccess.Contexto
{
    public class BibliotecaDbContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        public DbSet<Genero> Generos { get; set; }
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }
    }
}
