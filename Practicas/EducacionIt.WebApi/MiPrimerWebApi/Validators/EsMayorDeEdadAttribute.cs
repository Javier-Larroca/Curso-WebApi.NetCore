using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApi.Validators
{
    public class EsMayorDeEdadAttribute : ValidationAttribute
    {
        private readonly string _errorMessage = "La persona debe ser mayor de edad.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is not DateTime fechaNacimiento)
            {
                return new ValidationResult("La fecha enviada no cumple con el formato.");
            }

            var hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;

            // Si aún no cumplió años este año, restamos 1
            if (fechaNacimiento > hoy.AddYears(-edad))
            {
                edad--;
            }

            if (edad >= 18)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(_errorMessage);
        }
    }

}
