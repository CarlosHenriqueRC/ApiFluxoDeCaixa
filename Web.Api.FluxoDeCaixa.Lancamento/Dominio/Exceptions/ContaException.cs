namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Exceptions
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
