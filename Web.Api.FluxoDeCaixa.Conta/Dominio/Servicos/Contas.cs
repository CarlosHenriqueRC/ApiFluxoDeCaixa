using Web.Api.FluxoDeCaixa.Conta.Dominio.Exceptions;
using Entidade = Web.Api.FluxoDeCaixa.Conta.Dominio.Entidades;
using Web.Api.FluxoDeCaixa.Conta.Dominio.Servicos.Interfaces;

namespace Web.Api.FluxoDeCaixa.Conta.Dominio.Servicos
{
    public class Contas:IContas
    {
        public void verificarSeContaExiste(Entidade.Conta conta, IList<Entidade.Conta> contas)
        { 
            if (contas.Count > 1 || (contas.Count==1 && contas[0].id!=conta.id)) {
                throw new ContaException("Conta já cadastrada");
            }
        }

        public void verificarSeContaNaoExiste(Entidade.Conta conta)
        {
            if (conta==default)
            {
                throw new ContaException("Conta não existe");
            }
        }
    }
}
