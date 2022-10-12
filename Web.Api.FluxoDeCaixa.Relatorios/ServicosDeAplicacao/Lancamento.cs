using Web.Api.FluxoDeCaixa.Relatorios.ServicosDeAplicacao.Interfaces;
using VOs = Web.Api.FluxoDeCaixa.Relatorios.Dominio.VOs;
using Web.Api.FluxoDeCaixa.Relatorios.Dominio.Repositorios.Interfaces;
using ServicosDeDominio=Web.Api.FluxoDeCaixa.Relatorios.Dominio.Servicos.Interfaces;
using Web.Api.FluxoDeCaixa.Relatorios.Dominio.VOs;

namespace Web.Api.FluxoDeCaixa.Relatorios.ServicosDeAplicacao
{
    public class Lancamento : ILancamento
    {
        private readonly ILancamentos _lacamentosDeRepositorio;
        private readonly ServicosDeDominio.ILancamento _lancamentoDeServicosDeDominio;

        public Lancamento(ILancamentos lancamentoDeRepositorio, ServicosDeDominio.ILancamento lancamentoDeServicosDeDominio)
        {
            _lacamentosDeRepositorio = lancamentoDeRepositorio;
            _lancamentoDeServicosDeDominio = lancamentoDeServicosDeDominio;
        }

        public IList<VOs.DadosParaRelatorioConsolidado> ObterDadosParaRelatorioConsolidado(DateTime inicio, DateTime final)
        {

            var ListaDelancamentosDeDominio = _lacamentosDeRepositorio.ObterDadosParaRelatorioConsolidado(inicio, final);
            var listaDeDadosParaRelatorioConsolidado =  _lancamentoDeServicosDeDominio.ProcessarDadosParaRelatorioConsolidado(ListaDelancamentosDeDominio);

            return listaDeDadosParaRelatorioConsolidado;

        }

    }
}
