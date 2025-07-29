using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApi.Model
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Cuil), IsUnique = true)]
    public class Autor //: AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(11)]
        public string Cuil { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
