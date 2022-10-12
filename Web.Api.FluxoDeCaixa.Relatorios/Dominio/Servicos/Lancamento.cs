using Web.Api.FluxoDeCaixa.Relatorios.Dominio.Servicos.Interfaces;

namespace Web.Api.FluxoDeCaixa.Relatorios.Dominio.Servicos
{
    public class Lancamento:ILancamento
    {
        public IList<VOs.DadosParaRelatorioConsolidado> ProcessarDadosParaRelatorioConsolidado(IList<VOs.Lancamento> listaDeLancamentosDeDoiminio)
        {
            DateTime DiaCorrente = DateTime.MinValue;
            VOs.DadosParaRelatorioConsolidado dadosParaRelatorioConsolidado = new();
            IList<VOs.DadosParaRelatorioConsolidado> listaDeDadosParaRelatorioConsolidado = new List<VOs.DadosParaRelatorioConsolidado>();
            IList<VOs.LancamentosParaRelatorioConsolidado> lancamentosASeremMostrados = new List<VOs.LancamentosParaRelatorioConsolidado>();

            foreach (var LancamentoDeDominio in listaDeLancamentosDeDoiminio)
            {
                if (DiaCorrente.Date.CompareTo(LancamentoDeDominio.data.Date) != 0)
                {
                    DiaCorrente = LancamentoDeDominio.data.Date;
                    dadosParaRelatorioConsolidado = new();
                    lancamentosASeremMostrados = new List<VOs.LancamentosParaRelatorioConsolidado>();
                    dadosParaRelatorioConsolidado = new();
                    dadosParaRelatorioConsolidado.Data = DiaCorrente;
                    dadosParaRelatorioConsolidado.SaldoDiario = 0;
                    listaDeDadosParaRelatorioConsolidado.Add(dadosParaRelatorioConsolidado);
                }

                VOs.LancamentosParaRelatorioConsolidado lancamentoASeMostrado = new()
                {
                    descricaoDaConta = LancamentoDeDominio.conta.descricao,
                    valor = LancamentoDeDominio.tipo == "D" ? (-1) * LancamentoDeDominio.valor : LancamentoDeDominio.valor,
                    dataDoMovimento = LancamentoDeDominio.data,
                };
                dadosParaRelatorioConsolidado.SaldoDiario += lancamentoASeMostrado.valor;
                lancamentosASeremMostrados.Add(lancamentoASeMostrado);
                dadosParaRelatorioConsolidado.Lancamentos = lancamentosASeremMostrados;

            }

            return listaDeDadosParaRelatorioConsolidado;

        }

    }
}
