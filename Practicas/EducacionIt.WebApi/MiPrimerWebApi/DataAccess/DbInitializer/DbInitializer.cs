using MiPrimerWebApi.DataAccess.Contexto;
using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.DataAccess.DbInitializer
{
    public class DbInitializer
    {
        public static void Initialize(BibliotecaDbContext context)
        {
            if (context.Libros.Any() && context.Generos.Any() && context.Autores.Any())
            {
                return;
            }

            var terror = new Genero { Codigo = "TERR", Nombre = "Terror" };
            var fantasia = new Genero { Codigo = "FANT", Nombre = "Terror" };
            var policial = new Genero { Codigo = "POLI", Nombre = "Policial" };

            var autores = new Autor[]
            {
                new()
                {
                    Nombre = "Stephen King",
                    FechaNacimiento = new DateTime(1950, 01, 01),
                    Email = "sk@gmail.com",
                    Libros = [
                        new() {
                            Nombre = "Carrie",
                            Descripcion = "El primer libro de SK",
                            Generos = [terror]
                        },
                        new() {
                            Nombre = "Los Ojos del Dragón",
                            Descripcion = "Un libro de fantasía",
                            Generos = [fantasia, terror]
                        }
                    ]
                },
                new()
                {
                    Nombre = "J. K. Rowling",
                    FechaNacimiento = new DateTime(1960, 5, 2),
                    Email = "jkrowling@gmail.com",
                    Libros = [
                        new ()
                        {
                            Nombre = "Harry Potter y la piedra Filosofal",
                            Descripcion = "Un libro de fantasía",
                            Generos = [fantasia]
                        }
                    ]
                }
            };

            context.Autores.AddRange(autores);
            context.SaveChanges();
        }
    }
}
