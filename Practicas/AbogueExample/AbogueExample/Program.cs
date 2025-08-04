using Bogus;

namespace AbogueExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new ProductoGenerator();
            var producto = generator.Generate(10);
            foreach (var item in producto)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public required Categoria Categoria { get; set; }
        public decimal Total => Precio * Cantidad;

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Precio: {Precio}, Cantidad: {Cantidad}, Total: {Total}, Categoria: {Categoria.Nombre}";
        }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
    }

    public class CategoriaGenerator : Faker<Categoria>
    {
        public CategoriaGenerator() : base(locale: "es")
        {
            UseSeed(42)
                .RuleFor(x => x.Id, x => x.IndexFaker)
                .RuleFor(x => x.Nombre, x => x.Commerce.Categories(1)[0]);
        }

    }

    public class ProductoGenerator : Faker<Producto>
    {
        public ProductoGenerator() : base(locale: "es")
        {
            UseSeed(42)
                .RuleFor(x => x.Id, x => x.IndexFaker)
                .RuleFor(x => x.Nombre, x => x.Commerce.ProductName())
                .RuleFor(x => x.Precio, x => x.Random.Decimal(1, 10000))
                .RuleFor(x => x.Cantidad, x => x.Random.Number(1, 100))
                .RuleFor(x => x.Categoria, x => new CategoriaGenerator().Generate());
        }
    }
}
