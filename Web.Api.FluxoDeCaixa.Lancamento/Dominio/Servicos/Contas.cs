using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Exceptions;
using Entidade = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;
using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Interfaces;
using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;

namespace Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos
{
    public class Contas:IContas
    {
        
        public void verificarSeContaNaoExiste(Entidade.Conta conta)
        {
            if (conta==default)
            {
                throw new ContaException("Conta não existe");
            }
        }
    }
}
