namespace Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Persistencia
{
    public class Lancamento
    {
        public int id{ get; set; }
       // public Conta conta { get; set; }

        public decimal valor { get; set; }

        public DateTime data { get; set; }

        public string tipo { get; set; }
        public Conta conta { get; set; }

        public int idConta { get; set; }
    }
}
