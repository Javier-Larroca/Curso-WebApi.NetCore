using MiPrimerWebApi.Model;

namespace MiPrimerWebApi.DTOs
{
    public static class Mapper
    {
        public static Autor ToAutor(this AutorRequestDTO dto)
        {
            return new Autor
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                FechaNacimiento = dto.FechaNacimiento,
                Cuil = dto.Cuil
                //CreatedAt = DateTime.Now,
                //UpdatedAt = DateTime.Now,
            };
        }

        public static AutorResponseDTO ToResponse(this Autor autor)
        {
            return new AutorResponseDTO
            {
                Id = autor.Id,
                Nombre = autor.Nombre,
                Email = autor.Email,
                FechaNacimiento = autor.FechaNacimiento,
                Cuil = autor.Cuil,
                Libros = autor.Libros is not null ? autor.Libros.Select(l => new Libro
                {
                    Id = l.Id,
                    Nombre = l.Nombre,
                    FechaPublicacion = l.FechaPublicacion,
                    Generos = l.Generos
                }).ToList() : []
            };
        }

        public static Libro ToLibro(this LibroRequestDTO dto)
        {
            return new Libro
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                FechaPublicacion = dto.FechaPublicacion,
                Autor = new Autor
                {
                    Id = dto.AutorId
                },
                Generos = dto.Generos.Select(g => new Genero
                {
                    Codigo = g
                }).ToList()

            };
        }

        public static LibroResponseDTO ToResponse(this Libro libro)
        {
            return new LibroResponseDTO
            {
                Id = libro.Id,
                Nombre = libro.Nombre,
                FechaPublicacion = libro.FechaPublicacion,
                Descripcion = libro.Descripcion,
                Autor = new LibroAutorResponseDTO
                {
                    Id = libro.Autor.Id,
                    Nombre = libro.Autor.Nombre
                },
                Generos = libro.Generos
            };
        }
    }
}
