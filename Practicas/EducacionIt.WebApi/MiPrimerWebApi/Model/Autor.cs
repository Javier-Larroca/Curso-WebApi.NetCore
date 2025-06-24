using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApi.Model
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
