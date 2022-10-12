namespace Web.Api.FluxoDeCaixa.Relatorios.Dominio.Repositorios.Interfaces
{
    public interface ILancamentos
    {
        IList<VOs.Lancamento> ObterDadosParaRelatorioConsolidado(DateTime datainicio, DateTime datafinal);
    }
}
