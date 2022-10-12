namespace Web.Api.FluxoDeCaixa.Relatorios.InfraEstructura.Persistencia
{
    public class Lancamento
    {
        public int id { get; set; }
       // public Conta conta { get; set; }

        public decimal valor { get; set; }

        public DateTime data { get; set; }

        public string Tipo { get; set; }
        public Conta conta { get; set; }

        public int idConta { get; set; }
    }
}
