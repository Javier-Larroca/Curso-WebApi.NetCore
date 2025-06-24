using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiPrimerWebApi.Model
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descripcion { get; set; }
        public DateOnly? FechaPublicacion { get; set; }

        [JsonIgnore]
        public Autor? Autor { get; set; }
        public ICollection<Genero> Generos { get; set; }
    }
}
