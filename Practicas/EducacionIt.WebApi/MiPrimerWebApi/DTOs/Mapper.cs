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
    }
}
