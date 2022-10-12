using VO=Web.Api.FluxoDeCaixa.Lancamento.Dominio.VOs;
using Web.Api.FluxoDeCaixa.Lancamento.ServicosDeAplicacao.Interfaces;
using Repositorios=Web.Api.FluxoDeCaixa.Lancamento.Dominio.Repositorios.Interfaces;
using Entidade=Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;
using ServicosDeDominio = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Interfaces;

namespace Web.Api.FluxoDeCaixa.Lancamento.ServicosDeAplicacao
{
    public class Lancamento : ILancamento
    {

        private readonly Repositorios.ILancamentos _lancamentoRepositorio;
        private readonly Repositorios.IContas _contaRepositorio;
        private readonly ServicosDeDominio.IContas _contaServicosDeDominio;
        private readonly ServicosDeDominio.ILancamentos _lancamentoServicosDeDominio;

        public Lancamento(Repositorios.ILancamentos LancamentoRepositorio, ServicosDeDominio.IContas contaServicosDeDominio, Repositorios.IContas contaRepositorio, ServicosDeDominio.ILancamentos lancamentoServicosDeDominio)
        {
            _lancamentoRepositorio = LancamentoRepositorio;
            _contaServicosDeDominio = contaServicosDeDominio;
            _contaRepositorio = contaRepositorio;
            _lancamentoServicosDeDominio = lancamentoServicosDeDominio;
        }

        public bool Efetuar(VO.DadosParaEfetuarLancamento lancamento)
        {
            Entidade.Conta contaDeDominio = _contaRepositorio.ProcurarPeloID(lancamento.idConta);
            _contaServicosDeDominio.verificarSeContaNaoExiste(contaDeDominio);
            Entidade.Lancamento lancamentoDeDominio = new();
            lancamentoDeDominio.data = lancamento.Data;
            lancamentoDeDominio.valor = lancamento.valor;
            lancamentoDeDominio.tipo = lancamento.Tipo;
            lancamentoDeDominio.conta = contaDeDominio;
            lancamentoDeDominio.Validar();
            _lancamentoRepositorio.Efetuar(lancamentoDeDominio);
            return true;
        }

        public bool Estornar(int id)
        {
            Entidade.Lancamento lancamentoDeDominio = _lancamentoRepositorio.ProcurarPeloID(id);
            _lancamentoServicosDeDominio.verificarSeLancamentoExiste(lancamentoDeDominio);
            _lancamentoRepositorio.Efetuar(lancamentoDeDominio.GerarLancamentoDeEstorno());
            return true;
        }

        public IList<Dominio.VOs.DadosParaMostrarLancamento> RetornarLancamentosEntrePeriodo(DateTime datainicio, DateTime datafinal)
        {
            return _lancamentoRepositorio.RetornarLancamentosEntrePeriodo(datainicio,datafinal);
        }

    }
}
