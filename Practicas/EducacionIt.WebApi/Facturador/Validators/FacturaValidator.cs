using Facturador.DTOs;
using Facturador.Services;
using FluentValidation;
using System.Runtime.CompilerServices;

namespace Facturador.Validators
{
    public class FacturaValidator : AbstractValidator<FacturaDTO>
    {
        private readonly IDateService _dateService;
        public FacturaValidator(IDateService dateService) 
        {
            RuleFor(f => f.Monto)
                .NotNull()
                .GreaterThan(0).WithMessage("El monton debe ser mayor a 0.")
                .LessThan(1000000).WithMessage("El monto no puede ser mayor a 1.000.000");

            RuleFor(f => f.MedioDePago)
                .IsEnumName(typeof(MedioDePago), caseSensitive: false)
                .WithMessage("Los valores posibles con 'Cheque', 'Efectivo' o 'Tarjeta'");
            When(f => f.MedioDePago.Equals(MedioDePago.Efectivo.ToString(), StringComparison.InvariantCultureIgnoreCase), () =>
                {
                RuleFor(f => f.Cheque)
                    .Null()
                    .WithMessage("El metodo de pago es efectivo, no pasar datos de cheque.");
                RuleFor(f => f.Tarjeta)
                    .Null()
                    .WithMessage("El metodo de pago es efectivo, no pasar datos de tarjeta.");
                RuleFor(f => f.Efectivo)
                    .NotNull()
                    .WithMessage("El metodo de pago es efectivo, se necesitan datos.");
                RuleFor(f => f.Efectivo!.Monto)
                    .GreaterThanOrEqualTo(f => f.Monto)
                    .WithMessage("El monto a pagar en efectio no puiede ser menor al monto de la factura");
            });
            When(f => f.MedioDePago.Equals(MedioDePago.Cheque.ToString(), StringComparison.InvariantCultureIgnoreCase), () =>
            {
                RuleFor(f => f.Efectivo)
                    .Null()
                    .WithMessage("El metodo de pago es cheque, no pasar datos de efectivo.");
                RuleFor(f => f.Tarjeta)
                    .Null()
                    .WithMessage("El metodo de pago es cheque, no pasar datos de tarjeta.");
                RuleFor(f => f.Cheque)
                    .NotNull()
                    .WithMessage("El metodo de pago es cheque, se necesitan datos.");
                When(f => f.Cheque != null, () =>
                {
                    RuleFor(f => f.Cheque!.Codigo)
                        .NotNull().WithMessage("El codigo no puede estar vacio.")
                        .MaximumLength(10).WithMessage("El codigo no puede tener mas de 10 caracteres.");
                    RuleFor(f => f.Cheque!.Nombre)
                        .NotNull().WithMessage("El nombre no puede estar vacio.");
                });
            });

            When(f => f.MedioDePago.Equals(MedioDePago.Tarjeta.ToString(), StringComparison.InvariantCultureIgnoreCase), () =>
            {
                RuleFor(f => f.Efectivo)
                    .Null()
                    .WithMessage("El metodo de pago es tarjeta, no pasar datos de efectivo.");
                RuleFor(f => f.Cheque)
                    .Null()
                    .WithMessage("El metodo de pago es tarjeta, no pasar datos de cheque.");
                RuleFor(f => f.Tarjeta)
                    .NotNull()
                    .WithMessage("El metodo de pago es tarjeta, se necesitan datos.");
                RuleFor(f => f.Tarjeta!.Nombre)
                    .NotNull().WithMessage("El nombre no puede estar vacio.");
                RuleFor(f => f.Tarjeta!.Codigo)
                    .NotNull().WithMessage("El codigo de tarjeta no puede estar vacio.")
                    .InclusiveBetween((short)0, (short)999);
                RuleFor(f => f.Tarjeta!.Numero)
                    .NotNull().WithMessage("El numero de tarjeta no puede estar vacio.")
                    .CreditCard().WithMessage("No es numero de tarjeta valido");
                RuleFor(f => f.Tarjeta.FechaVencimiento)
                    .NotNull().WithMessage("Las fecha de vencimiento no puede estar vacia.")
                    .MustAsync(ValidacionFechaMayorAHoy);
            });

        }

        private async Task<bool> ValidacionFechaMayorAHoy(DateOnly fechavencimiento, CancellationToken cancellationToken)
        {
            return await _dateService.IsFechaMayorAHoy(fechavencimiento);
        }
    }
}
