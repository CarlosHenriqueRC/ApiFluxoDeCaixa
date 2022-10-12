namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.VOs
{
    public class DadosParaEfetuarLancamento
    {
        public int idConta { get; set; }
        public decimal valor { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
    }
}
