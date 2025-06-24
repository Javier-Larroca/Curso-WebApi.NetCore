using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiPrimerWebApi.Model
{
    public class Genero
    {
        [Key]
        [StringLength(4)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [JsonIgnore]
        public ICollection<Libro>? Libros { get; set; }
    }
}
