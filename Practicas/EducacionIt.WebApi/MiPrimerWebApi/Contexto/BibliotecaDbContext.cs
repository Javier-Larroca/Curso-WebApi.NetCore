using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi.Entidades;

namespace MiPrimerWebApi.Contexto
{
    public class BibliotecaDbContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }
    }
}
