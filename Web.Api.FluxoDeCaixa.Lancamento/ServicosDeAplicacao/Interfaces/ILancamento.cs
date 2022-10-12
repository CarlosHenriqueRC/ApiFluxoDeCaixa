using VOs = Web.Api.FluxoDeCaixa.Lancamento.Dominio.VOs;

namespace Web.Api.FluxoDeCaixa.Lancamento.ServicosDeAplicacao.Interfaces
{
    public interface ILancamento
    {
        bool Efetuar(VOs.DadosParaEfetuarLancamento lancamento);
        bool Estornar(int id);
        IList<VOs.DadosParaMostrarLancamento> RetornarLancamentosEntrePeriodo(DateTime inicio, DateTime final);
    }
}
