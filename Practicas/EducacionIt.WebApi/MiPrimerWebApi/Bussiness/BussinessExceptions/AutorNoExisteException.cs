namespace MiPrimerWebApi.Bussiness.BussinessExceptions
{
    public class AutorNoExisteException : BussinessException
    {
        public AutorNoExisteException(int id) : base($"Autor con id {id} no existe.") { }
    }
}
