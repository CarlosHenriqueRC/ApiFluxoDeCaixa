namespace Web.Api.FluxoDeCaixa.Relatorios.Dominio.VOs
{
    public class DadosParaRelatorioConsolidado
    {

        public DadosParaRelatorioConsolidado()
        {
            Lancamentos = new List<LancamentosParaRelatorioConsolidado>();
        }

        public DateTime Data { get; set; }
        public Decimal SaldoDiario { get; set; }
        public IList<LancamentosParaRelatorioConsolidado> Lancamentos { get; set; }
    }
}
