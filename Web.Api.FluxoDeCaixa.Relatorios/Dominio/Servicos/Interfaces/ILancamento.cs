namespace Web.Api.FluxoDeCaixa.Relatorios.Dominio.Servicos.Interfaces
{
    public interface ILancamento
    {
        IList<VOs.DadosParaRelatorioConsolidado> ProcessarDadosParaRelatorioConsolidado(IList<VOs.Lancamento> listaDeLancamentosDeDoiminio);
    }
}
