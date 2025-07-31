using MiPrimerWebApi.Model;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApi.DTOs
{
    public class LibroResponseDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public DateOnly? FechaPublicacion { get; set; }

        public LibroAutorResponseDTO? Autor { get; set; }
        public ICollection<Genero> Generos { get; set; }
    }

    public class LibroAutorResponseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class LibroRequestDTO
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descripcion { get; set; }
        public DateOnly? FechaPublicacion { get; set; }
        public int AutorId { get; set; }
        public ICollection<string> Generos { get; set; }
    }
}
