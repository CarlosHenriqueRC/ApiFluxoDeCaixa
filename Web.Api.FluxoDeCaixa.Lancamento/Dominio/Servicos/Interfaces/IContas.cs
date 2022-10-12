using Entidade = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;

namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Interfaces
{
    public interface IContas
    {

        void verificarSeContaNaoExiste(Entidade.Conta conta);
    }
}
