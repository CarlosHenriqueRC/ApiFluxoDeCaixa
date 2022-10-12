using Entidade = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;

namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Repositorios.Interfaces
{
    public interface IContas
    {
        Entidade.Conta ProcurarPeloID(int id);

    }
}
