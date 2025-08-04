using Bogus;
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
                    Cuil = "1",
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
                    Cuil = "2",
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

        //internal static class Fakerconstants
        //{
        //    public const int SEED = 42;
        //    public const string LOCALE = "es";
        //}
        //internal class GeneroGenerator : Faker<Genero>
        //{
        //    public GeneroGenerator() : base (locale: Fakerconstants.LOCALE)
        //    {
        //        string[] generos = ["Fantasia", "Terror"];
        //        UseSeed(Fakerconstants.SEED)
        //            .RuleFor(x=> x.Codigo, x => x.PickRandom(generos))
        //            .RuleFor(x=> x.Nombre, x=> x.)
        //    }
        //}
    }
}
