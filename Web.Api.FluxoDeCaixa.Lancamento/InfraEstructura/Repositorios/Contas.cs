using Microsoft.EntityFrameworkCore;
using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Repositorios.Interfaces;
using Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Persistencia;
using Entidade = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;
using Persistencia= Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Persistencia;

namespace Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Repositorios
{
    public class Contas : IContas
    {

        private readonly FluxoDeCaixaContext _FluxoDeCaixa_Context;
        public Contas(FluxoDeCaixaContext ContextFluxoDeCaixa)
        {
            _FluxoDeCaixa_Context = ContextFluxoDeCaixa;
        }


        public Entidade.Conta ProcurarPeloID(int id)
        {
            var contaDePersistencia = _FluxoDeCaixa_Context.contas.Where(c => c.id == id).FirstOrDefault();
            Entidade.Conta contaDeDominio = default;
            if (contaDePersistencia != default)
            {
                contaDeDominio = new();
                contaDeDominio.id = contaDePersistencia.id;
                contaDeDominio.descricao = contaDePersistencia.descricao;
                contaDeDominio.ativa = contaDePersistencia.ativa;
            }

            return contaDeDominio;
        }

    }
}
