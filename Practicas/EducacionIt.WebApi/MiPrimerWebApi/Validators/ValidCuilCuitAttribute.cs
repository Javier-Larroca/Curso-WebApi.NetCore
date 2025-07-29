using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApi.Validators
{
    public class ValidCuilCuitAttribute : ValidationAttribute
    {
        private readonly string _errorMessage = "Invalid CUIT/CUIL";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string cuitCuil)
            {
                return new ValidationResult("El campo deberia ser un string");
            }

            var cuitNro = cuitCuil.Replace("-", "");
            if (cuitNro.Length != 11)
            {
                return new ValidationResult("El campo deberia tener 11 caracteres");
            }

            var resultado = 0;
            var codigos = "6789456789";
            var verificador = int.Parse(cuitNro.Substring(cuitNro.Length - 1, 1));

            var x = 0;
            while (x < 10)
            {
                var digitoValidador = int.Parse(cuitNro.Substring(x, 1));
                var digitoCodigo = int.Parse(codigos.Substring(x, 1));
                resultado += digitoValidador * digitoCodigo;
                x++;
            }

            resultado %= 11;
            if (resultado == verificador)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(_errorMessage);
        }
    }
}
