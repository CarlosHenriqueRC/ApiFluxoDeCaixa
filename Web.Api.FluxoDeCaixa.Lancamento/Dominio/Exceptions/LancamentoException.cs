namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Exceptions
{
    public class LancamentoException : Exception
    {

        public LancamentoException(string message)
            : base(message)
        {
        }

        public LancamentoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
