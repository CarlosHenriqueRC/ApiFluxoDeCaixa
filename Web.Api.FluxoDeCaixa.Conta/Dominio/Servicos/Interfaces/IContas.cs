using Entidade = Web.Api.FluxoDeCaixa.Conta.Dominio.Entidades;

namespace Web.Api.FluxoDeCaixa.Conta.Dominio.Servicos.Interfaces
{
    public interface IContas
    {
        void verificarSeContaExiste(Entidade.Conta conta, IList<Entidade.Conta> contas);

        void verificarSeContaNaoExiste(Entidade.Conta conta);
    }
}
