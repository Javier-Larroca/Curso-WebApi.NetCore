using MiPrimerWebApi.Model;
using MiPrimerWebApi.Validators;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApi.DTOs
{
    public record AutorRequestDTO
    {
        private string _cuil = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        [ValidCuilCuit]
        public string Cuil { get => _cuil; set
            {
                _cuil = value.Replace("-", "");
            } 
        }

        [EsMayorDeEdad]
        public DateTime? FechaNacimiento { get; set; }
    }

    public record AutorResponseDTO : AutorRequestDTO
    {
        public int Id { get; set; }
        public List<Libro> Libros { get; set; }
    }

    //public record AutorOrderBy
    //{
    //    public string OrderBy { get; set; }
    //    public Func<Autor, object> OrderByFunc => 
    //        OrderBy switch 
    //        {
    //            "Id" => a => a.Id,
    //        }
    //}

}
