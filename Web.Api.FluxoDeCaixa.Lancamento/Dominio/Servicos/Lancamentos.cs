using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Interfaces;
using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Exceptions;

namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos
{
    public class Lancamentos : ILancamentos
    {
        public void verificarSeLancamentoExiste(Entidades.Lancamento lancamento)
        {
            if (lancamento == default)
            {
                throw new LancamentoException("Lancamento não existe");
            }
        }
    }
}
