using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi.DataAccess.Contexto;

namespace MiPrimerWebApi.DataAccess.DbInitializer
{
    public static class DatabaseExtensions
    {
        public static void CreateDbIfNotExist(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BibliotecaDbContext>();
            //context.Database.EnsureCreated(); // Una opción
            context.Database.Migrate(); //Otra opción
            DbInitializer.Initialize(context);
        }
    }
}
