namespace MiPrimerWebApi.Bussiness.BussinessExceptions
{
    public class LibroNoExisteException : BussinessException
    {
        public LibroNoExisteException(int id) : base($"Libro con id {id} no existe.") { }
    }
}
