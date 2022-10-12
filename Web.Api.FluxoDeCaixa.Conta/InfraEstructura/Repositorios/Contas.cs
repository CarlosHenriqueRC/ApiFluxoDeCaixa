using Microsoft.EntityFrameworkCore;
using Web.Api.FluxoDeCaixa.Conta.Dominio.Repositorios.Interfaces;
using Web.Api.FluxoDeCaixa.Conta.InfraEstructura.Persistencia;
using Dominio = Web.Api.FluxoDeCaixa.Conta.Dominio.Entidades;
using Persistencia = Web.Api.FluxoDeCaixa.Conta.InfraEstructura.Persistencia;
using Entidade = Web.Api.FluxoDeCaixa.Conta.Dominio.Entidades;

namespace Web.Api.FluxoDeCaixa.Conta.InfraEstructura.Repositorios
{
    public class Contas : IContas
    {

        private readonly FluxoDeCaixaContext _FluxoDeCaixaContext;
        public Contas(FluxoDeCaixaContext ContextFluxoDeCaixa)
        {
            _FluxoDeCaixaContext = ContextFluxoDeCaixa;
        }

        public Entidade.Conta Adicionar(Entidade.Conta conta)
        {
            Persistencia.Conta contaDePersistencia = new();
            contaDePersistencia.descricao = conta.descricao;
            contaDePersistencia.ativa = conta.ativa;
            _FluxoDeCaixaContext.Contas.Add(contaDePersistencia);
            _FluxoDeCaixaContext.SaveChanges();
            conta.id = contaDePersistencia.id;
            return conta;
        }

        public bool Alterar(Entidade.Conta conta)
        {
            Persistencia.Conta contaDePersistencia = _FluxoDeCaixaContext.Contas.Find(conta.id);
            contaDePersistencia.descricao = conta.descricao;
            contaDePersistencia.ativa = conta.ativa;
            _FluxoDeCaixaContext.Contas.Update(contaDePersistencia);
            _FluxoDeCaixaContext.SaveChanges();
            conta.id = contaDePersistencia.id;
            return true;
        }

        public IList<Entidade.Conta> ListarTodasAsContas(int ultimoIdPaginaAnterior, int quantidadeDeRegistrosPorPagina)
        {
            IList<Entidade.Conta> listaDeContasDoDominio = new List<Entidade.Conta>();
            var listaDeContasePersistenciaM = _FluxoDeCaixaContext.Contas.Where(c=>c.id>ultimoIdPaginaAnterior)
                                                                .Take(quantidadeDeRegistrosPorPagina)
                                                                .ToList();

            foreach (var contaDePersistencia in listaDeContasePersistenciaM)
            {
                Entidade.Conta contaDeDominio = new();
                contaDeDominio.id = contaDePersistencia.id;
                contaDeDominio.descricao = contaDePersistencia.descricao;
                contaDeDominio.ativa = contaDePersistencia.ativa;
                listaDeContasDoDominio.Add(contaDeDominio);
            }

            return listaDeContasDoDominio;
        }

        public Entidade.Conta ProcurarPeloID(int id)
        {
            var contaDePersistencia = _FluxoDeCaixaContext.Contas.Where(c => c.id == id).FirstOrDefault();
            Dominio.Entidades.Conta contaDeDominio = default;
            if (contaDePersistencia != default)
            {
                contaDeDominio = new();
                contaDeDominio.id = contaDePersistencia.id;
                contaDeDominio.descricao = contaDePersistencia.descricao;
                contaDeDominio.ativa = contaDePersistencia.ativa;
            }

            return contaDeDominio;
        }

        public IList<Entidade.Conta> ProcurarPorDescricao(string descricao)
        {
            IList<Entidade.Conta> listaDeContasDoDominio = new List<Entidade.Conta>();
            var listaDeContasDePersistencia = _FluxoDeCaixaContext.Contas.Where(c => c.descricao == descricao).ToList();


            foreach(var contaDePersistencia in listaDeContasDePersistencia)
            {
                Entidade.Conta contaDeDominio = new();
                contaDeDominio.id = contaDePersistencia.id;
                contaDeDominio.descricao = contaDePersistencia.descricao;
                contaDeDominio.ativa = contaDePersistencia.ativa;
                listaDeContasDoDominio.Add(contaDeDominio);
            }

            return listaDeContasDoDominio;

        }
    }
}
