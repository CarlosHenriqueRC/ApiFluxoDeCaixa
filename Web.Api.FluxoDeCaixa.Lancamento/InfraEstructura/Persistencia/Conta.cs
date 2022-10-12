namespace Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Persistencia
{
    public class Conta
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public bool ativa { get; set; }

        public IEnumerable<Lancamento> lancamentos { get; set; }
    }
}
