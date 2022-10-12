using VOs = Web.Api.FluxoDeCaixa.Relatorios.Dominio.VOs;

namespace Web.Api.FluxoDeCaixa.Relatorios.ServicosDeAplicacao.Interfaces
{
    public interface ILancamento
    {
        IList<VOs.DadosParaRelatorioConsolidado> ObterDadosParaRelatorioConsolidado(DateTime inicio, DateTime final);
    }
}
