using VO = Web.Api.FluxoDeCaixa.Lancamento.Dominio.VOs;

namespace Web.Api.FluxoDeCaixa.Lancamento.ServicosDeAplicacao.Interfaces
{
    public interface IConta
    {
        int adicionar(VO.Conta conta);
        bool alterar(VO.Conta conta);
        bool excluir(int id);
        IList<VO.Conta> listar(int UltimoIdPaginaAnterior, int QuantidadeDeRegistrosPorPagina);
        public VO.Conta consultar(int Id);
    }
}
