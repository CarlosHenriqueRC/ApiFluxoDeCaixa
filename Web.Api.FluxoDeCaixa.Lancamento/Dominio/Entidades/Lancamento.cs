using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Exceptions;

namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades
{
    public class Lancamento
    {
        public int id { get; set; }
        public Conta conta { get; set; }

        public decimal valor { get; set; }

        public DateTime data { get; set; }

        public string tipo { get; set; }

        public void Validar()
        {
            if (this.valor<= 0)
            {
                throw new LancamentoException("Valor do lancamento inválido");
            }

            if (this.tipo != "D" && this.tipo != "C")
            {
                throw new LancamentoException("Tipo de Lançamento inválido");
            }

            if (conta==default || conta==null)
            {
                throw new LancamentoException("conta inválida");
            }
        }

        public Lancamento GerarLancamentoDeEstorno()
        {
            Lancamento lancamentoDeEstorno = new()
            {
                id = this.id,
                conta = this.conta,
                valor = this.valor,
                data = this.data,
                tipo = this.tipo == "D" ? "C" : "D"
            };

            return lancamentoDeEstorno;
        } 
    }
}
