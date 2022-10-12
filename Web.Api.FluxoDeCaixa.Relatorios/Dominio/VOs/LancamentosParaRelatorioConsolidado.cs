namespace Web.Api.FluxoDeCaixa.Relatorios.Dominio.VOs
{
    public class LancamentosParaRelatorioConsolidado
    {
        public string descricaoDaConta { get; set; }
        public DateTime dataDoMovimento { get; set; }
        public decimal valor { get; set; }

    }
}
