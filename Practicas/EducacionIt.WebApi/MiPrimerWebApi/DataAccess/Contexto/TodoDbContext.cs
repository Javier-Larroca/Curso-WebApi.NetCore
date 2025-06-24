using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.DataAccess.Contexto
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
    }
}
