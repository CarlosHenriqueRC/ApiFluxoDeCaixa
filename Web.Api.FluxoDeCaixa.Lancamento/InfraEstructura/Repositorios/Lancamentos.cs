using Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Persistencia;
using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Repositorios.Interfaces;
using Persistencia = Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Persistencia;
using Entidade = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;
using VOs = Web.Api.FluxoDeCaixa.Lancamento.Dominio.VOs;

using Microsoft.EntityFrameworkCore;

namespace Web.Api.FluxoDeCaixa.Lancamento.InfraEstructura.Repositorios
{
    public class Lancamentos:ILancamentos
    {

        private readonly FluxoDeCaixaContext _FluxoDeCaixaContext;
        public Lancamentos(FluxoDeCaixaContext fluxoDeCaixaContext)
        {
            _FluxoDeCaixaContext = fluxoDeCaixaContext;
        }

        public Entidade.Lancamento Efetuar(Entidade.Lancamento lancamento)
        {
            Persistencia.Lancamento LancamentoDePersistencia = new();
            LancamentoDePersistencia.data = lancamento.data;
            LancamentoDePersistencia.valor = lancamento.valor;
            LancamentoDePersistencia.tipo = lancamento.tipo;
            LancamentoDePersistencia.idConta = lancamento.conta.id;
            _FluxoDeCaixaContext.lancamentos.Add(LancamentoDePersistencia);
            _FluxoDeCaixaContext.SaveChanges();
            lancamento.id = LancamentoDePersistencia.id;
            return lancamento;
        }

        public Entidade.Lancamento ProcurarPeloID(int Id)
        {
            var lancamentoDePersistencia = _FluxoDeCaixaContext.lancamentos.Include(c => c.conta)
                                                                  .Where(c => c.id == Id).FirstOrDefault();
            Entidade.Lancamento lancamentoDeDominio = new();
            if (lancamentoDePersistencia != default)
            {
                lancamentoDeDominio.data = lancamentoDePersistencia.data;
                lancamentoDeDominio.valor = lancamentoDePersistencia.valor;
                lancamentoDeDominio.tipo = lancamentoDePersistencia.tipo;
                lancamentoDeDominio.conta = new();
                lancamentoDeDominio.conta.id = lancamentoDePersistencia.conta.id;
                lancamentoDeDominio.conta.descricao = lancamentoDePersistencia.conta.descricao;
                lancamentoDeDominio.conta.ativa = lancamentoDePersistencia.conta.ativa;
            }

            return lancamentoDeDominio;
        }

        public IList<VOs.DadosParaMostrarLancamento> RetornarLancamentosEntrePeriodo(DateTime inicio, DateTime final)
        {
            IList<VOs.DadosParaMostrarLancamento> listaDeLancamentosASeremMostrados = new List<VOs.DadosParaMostrarLancamento>();
            var listaDeLancamentosDePersistencia = _FluxoDeCaixaContext.lancamentos.Include(c => c.conta)
                                                                          .Where(c => c.data >= inicio 
                                                                                 && c.data <= final)
                                                                          .OrderBy(c=>c.id)
                                                                          .ToList();

            foreach (var lancamentoDePersistencia in listaDeLancamentosDePersistencia)
            {
                VOs.DadosParaMostrarLancamento LancamentosASeremMostrados = new();
                LancamentosASeremMostrados.id = lancamentoDePersistencia.id;
                LancamentosASeremMostrados.valor = lancamentoDePersistencia.valor;
                LancamentosASeremMostrados.descricaoDaConta = lancamentoDePersistencia.conta.descricao;
                LancamentosASeremMostrados.data = lancamentoDePersistencia.data;
                LancamentosASeremMostrados.tipo = lancamentoDePersistencia.tipo;
                listaDeLancamentosASeremMostrados.Add(LancamentosASeremMostrados);
            }

            return listaDeLancamentosASeremMostrados;
        }
    }
}
