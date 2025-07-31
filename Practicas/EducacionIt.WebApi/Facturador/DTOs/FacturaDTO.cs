namespace Facturador.DTOs
{
    public class FacturaDTO
    {
        public int Monto { get; set; }
        public string MedioDePago { get; set; }
        public Tarjeta? Tarjeta { get; set; }
        public Cheque? Cheque { get; set; }
        public Efectivo? Efectivo { get; set; }
    }

    public enum MedioDePago
    {
        Tarjeta,
        Efectivo, 
        Cheque
    }

    public class Efectivo
    {
        public double Monto { get; set; }
    }

    public class Cheque
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    public class  Tarjeta
    {
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public short Codigo { get; set; }
        public DateOnly FechaVencimiento { get; set; }
    }
}
