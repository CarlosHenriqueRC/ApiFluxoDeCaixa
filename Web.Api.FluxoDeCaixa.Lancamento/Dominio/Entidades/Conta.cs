using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Exceptions;

namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades
{
    public class Conta
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public bool ativa { get; set; }

        public void Validar()
        {
            if (this.descricao.Trim().Length ==0)
            {
                throw new ContaException("Descrição inválida");
            }

        }
    }
}
