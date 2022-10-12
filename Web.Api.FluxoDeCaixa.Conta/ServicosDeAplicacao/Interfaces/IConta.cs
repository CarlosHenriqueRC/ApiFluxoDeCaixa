using VOs = Web.Api.FluxoDeCaixa.Conta.Dominio.VOs;

namespace Web.Api.FluxoDeCaixa.Conta.ServicosDeAplicacao.Interfaces
{
    public interface IConta
    {
        int Adicionar(VOs.Conta conta);
        bool Alterar(VOs.Conta conta);
        IList<VOs.Conta> Listar(int ultimoIdPaginaAnterior, int quantidadeDeRegistrosPorPagina);
        public VOs.Conta Consultar(int id);
    }
}
