namespace Web.Api.FluxoDeCaixa.Conta.Dominio.Exceptions
{
    public class ContaException : Exception
    {

        public ContaException(string message)
            : base(message)
        {
        }

        public ContaException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
