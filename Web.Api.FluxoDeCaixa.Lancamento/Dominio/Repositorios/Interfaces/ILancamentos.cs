using Entidade =Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;
using VOs = Web.Api.FluxoDeCaixa.Lancamento.Dominio.VOs;

namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Repositorios.Interfaces
{
    public interface ILancamentos
    {
        Entidade.Lancamento Efetuar(Entidade.Lancamento lancamento);

        Entidade.Lancamento ProcurarPeloID(int id);
        IList<VOs.DadosParaMostrarLancamento> RetornarLancamentosEntrePeriodo(DateTime inicio, DateTime final);
    }
}
