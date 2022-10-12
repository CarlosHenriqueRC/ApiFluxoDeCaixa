using Web.Api.FluxoDeCaixa.Conta.ServicosDeAplicacao.Interfaces;
using VOs = Web.Api.FluxoDeCaixa.Conta.Dominio.VOs;
using Entidade =Web.Api.FluxoDeCaixa.Conta.Dominio.Entidades;
using ServicoDeDominio=Web.Api.FluxoDeCaixa.Conta.Dominio.Servicos.Interfaces;
using Repositorio= Web.Api.FluxoDeCaixa.Conta.Dominio.Repositorios.Interfaces;

namespace Web.Api.FluxoDeCaixa.Conta.ServicosDeAplicacao
{
    public class Conta:IConta
    {

        private readonly ServicoDeDominio.IContas _ContaServicosDeDominio;
        private readonly Repositorio.IContas _ContaDeRepositorio;

        public Conta(ServicoDeDominio.IContas ContaServicosDeDominio,Repositorio.IContas ContaDeRepositorio)
        {
            _ContaServicosDeDominio = ContaServicosDeDominio;
            _ContaDeRepositorio = ContaDeRepositorio;
        }

        public int Adicionar(VOs.Conta conta)
        {
            Entidade.Conta ContaDeDominio = new ();
            ContaDeDominio.ativa = true;
            ContaDeDominio.descricao = conta.descricao;
            ContaDeDominio.Validar();
            _ContaServicosDeDominio.verificarSeContaExiste(ContaDeDominio,_ContaDeRepositorio.ProcurarPorDescricao(conta.descricao));
            _ContaDeRepositorio.Adicionar(ContaDeDominio);
            return ContaDeDominio.id;
        }
        public bool Alterar(VOs.Conta contaDeVO)
        {
            Entidade.Conta contaDeDominio = new();
            contaDeDominio.id = contaDeVO.id;
            contaDeDominio.ativa = contaDeVO.ativa;
            contaDeDominio.descricao = contaDeVO.descricao;
            contaDeDominio.Validar();
            _ContaServicosDeDominio.verificarSeContaExiste(contaDeDominio, _ContaDeRepositorio.ProcurarPorDescricao(contaDeVO.descricao));
            _ContaServicosDeDominio.verificarSeContaNaoExiste(_ContaDeRepositorio.ProcurarPeloID(contaDeVO.id));
            _ContaDeRepositorio.Alterar(contaDeDominio);
            return true;
        }

        public IList<VOs.Conta> Listar(int ultimoIdPaginaAnterior, int quantidadeDeRegistrosPorPagina)
        {

            IList<VOs.Conta> listaDeContasDeVO = new List<VOs.Conta>();

            var listaDeContasDeDominio = _ContaDeRepositorio.ListarTodasAsContas(ultimoIdPaginaAnterior, quantidadeDeRegistrosPorPagina);

            foreach (Entidade.Conta contaDeDominio in listaDeContasDeDominio)
            {
                VOs.Conta contaDeVO = new();
                contaDeVO.id= contaDeDominio.id;
                contaDeVO.descricao = contaDeDominio.descricao;
                contaDeVO.ativa = contaDeDominio.ativa;
                listaDeContasDeVO.Add(contaDeVO);
            }

            return listaDeContasDeVO;
        }

        public VOs.Conta Consultar(int id)
        {
            Entidade.Conta conta = _ContaDeRepositorio.ProcurarPeloID(id);
            _ContaServicosDeDominio.verificarSeContaNaoExiste(conta);
            VOs.Conta contaDeVO = new();
            contaDeVO.id = conta.id;
            contaDeVO.descricao = conta.descricao;
            contaDeVO.ativa = conta.ativa;
            return contaDeVO;
        }
    }
}
