namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.VOs
{
    public class DadosParaMostrarLancamento
    {
        public int id { get; set; }
        public string descricaoDaConta { get; set; }
        public decimal valor { get; set; }
        public DateTime data { get; set; }
        public string tipo { get; set; }
    }
}
