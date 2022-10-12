using Entidade=Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;

namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Interfaces
{
    public interface ILancamentos
    {
        void verificarSeLancamentoExiste(Entidade.Lancamento Lancamento);
    }
}
