namespace Web.Api.FluxoDeCaixa.Relatorios.InfraEstructura.Persistencia
{
    public class Conta
    {
        public int Id { get; set; }
        public string descricao { get; set; }
        public bool ativa { get; set; }

        public IEnumerable<Lancamento> Lancamentos { get; set; }
    }
}
