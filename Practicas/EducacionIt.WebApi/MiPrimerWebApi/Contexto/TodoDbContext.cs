using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi.Entidades;

namespace MiPrimerWebApi.Contexto
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
    }
}
