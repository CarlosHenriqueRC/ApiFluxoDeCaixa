using Entidade=Web.Api.FluxoDeCaixa.Conta.Dominio.Entidades;

namespace Web.Api.FluxoDeCaixa.Conta.Dominio.Repositorios.Interfaces
{
    public interface IContas
    {
        Entidade.Conta Adicionar(Entidade.Conta conta);

        IList<Entidade.Conta> ProcurarPorDescricao(string descricao);

        Entidade.Conta ProcurarPeloID(int id);

        bool Alterar(Entidade.Conta conta);

        IList<Entidade.Conta> ListarTodasAsContas(int ultimoIdPaginaAnterior, int quantidadeDeRegistrosPorPagina);
    }
}
