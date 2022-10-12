using Web.Api.FluxoDeCaixa.Relatorios.InfraEstructura.Persistencia;
using Web.Api.FluxoDeCaixa.Relatorios.Dominio.Repositorios.Interfaces;
using VOs=Web.Api.FluxoDeCaixa.Relatorios.Dominio.VOs;

using Microsoft.EntityFrameworkCore;

namespace Web.Api.FluxoDeCaixa.Relatorios.InfraEstructura.Repositorios
{
    public class Lancamentos:ILancamentos
    {

        private readonly FluxoDeCaixaContext _ContextFluxoDeCaixa;
        public Lancamentos(FluxoDeCaixaContext fluxoDeCaixaContext)
        {
            _ContextFluxoDeCaixa = fluxoDeCaixaContext;
        }

       public IList<VOs.Lancamento> ObterDadosParaRelatorioConsolidado(DateTime datainicio, DateTime datafinal)
        {

            DateTime DiaCorrente = DateTime.MinValue;
            VOs.DadosParaRelatorioConsolidado dadosParaRelatorioConsolidado=new();
            IList<VOs.Lancamento> listaDeDadosParaRelatorioConsolidado = new List<VOs.Lancamento>();

            var listaDeLancamentosDePersistencia = _ContextFluxoDeCaixa.Lancamentos.Include(c => c.conta)
                                                                          .Where(c => c.data >= datainicio 
                                                                                 && c.data <= datafinal)
                                                                          .OrderBy(c=>c.data)
                                                                          .ToList();

            foreach (var LancamentoDePersistencia in listaDeLancamentosDePersistencia)
            {

                VOs.Conta contaDeVO = new()
                {
                    Id = LancamentoDePersistencia.conta.Id,
                    ativa = LancamentoDePersistencia.conta.ativa,
                    descricao = LancamentoDePersistencia.conta.descricao,
                };

                VOs.Lancamento lancamentoDeVO = new()
                {
                    id = LancamentoDePersistencia.id,
                    valor =LancamentoDePersistencia.valor,
                    data =LancamentoDePersistencia.data,
                    tipo = LancamentoDePersistencia.Tipo,
                    conta = contaDeVO,
                 };


                listaDeDadosParaRelatorioConsolidado.Add(lancamentoDeVO);

            }

            return listaDeDadosParaRelatorioConsolidado;
        }
    }
}
