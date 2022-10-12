using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Web.Api.FluxoDeCaixa.Relatorios.Dominio.Servicos.Interfaces;
using VOs = Web.Api.FluxoDeCaixa.Relatorios.Dominio.VOs;

namespace Web.Api.FluxoDeCaixa.Relatorios.Testes.ServicosDeDominioTestes
{
    public class Lancamento
    {
        private readonly ILancamento _lancamentoServicosDeDominio;

        public Lancamento()
        {
            _lancamentoServicosDeDominio = new Web.Api.FluxoDeCaixa.Relatorios.Dominio.Servicos.Lancamento();
        }


        [Fact]
        public void ProcessarDadosParaRelatorioConsolidade_DeveRetornarDados()
        {
           var dadosParaRelatorioConsolidado =  _lancamentoServicosDeDominio.ProcessarDadosParaRelatorioConsolidado(montaLancamentosDeVO());

            Assert.True(dadosParaRelatorioConsolidado.Count() == 2);
            Assert.True(dadosParaRelatorioConsolidado[0].Data.Date == DateTime.Parse("02/10/2022").Date);
            Assert.True(dadosParaRelatorioConsolidado[1].Data.Date == DateTime.Parse("03/10/2022").Date);
            Assert.True(dadosParaRelatorioConsolidado[0].SaldoDiario == 45.25M);
            Assert.True(dadosParaRelatorioConsolidado[1].SaldoDiario == -35.30M);
            Assert.True(dadosParaRelatorioConsolidado[0].Lancamentos.Count() == 2);
            Assert.True(dadosParaRelatorioConsolidado[1].Lancamentos.Count() == 2);
        }

        [Fact]
        public void ProcessarDadosParaRelatorioConsolidado_NaoDeveRetornarDados()
        {
            var dadosParaRelatorioConsolidado = _lancamentoServicosDeDominio.ProcessarDadosParaRelatorioConsolidado(new List<VOs.Lancamento> ());

            Assert.True(dadosParaRelatorioConsolidado.Count == 0);
        }

        private IList<VOs.Lancamento> montaLancamentosDeVO()
        {
            IList<VOs.Lancamento> lancamentosDeVO = new List<VOs.Lancamento>
            {
             new VOs.Lancamento() { id = 0, data = DateTime.Parse("02/10/2022 10:20:00"), tipo = "C", valor = 10.15M,conta = new VOs.Conta() { Id = 1, ativa = true, descricao = "Caneta" } },
             new VOs.Lancamento() { id = 1, data = DateTime.Parse("02/10/2022 14:10:00"), tipo = "C", valor = 35.10M,conta = new VOs.Conta() { Id = 2, ativa = true, descricao = "Lapis" } },
             new VOs.Lancamento() { id = 2, data = DateTime.Parse("03/10/2022 00:15:00"), tipo = "C", valor = 5.0M,conta = new VOs.Conta() { Id = 3, ativa = true, descricao = "Copo" } },
             new VOs.Lancamento() { id = 3, data = DateTime.Parse("03/10/2022 13:00:03"), tipo = "D", valor = 40.30M,conta = new VOs.Conta() { Id = 4, ativa = true, descricao = "Garrafão de Água" } },
            };

            return lancamentosDeVO;

        }
    }
}
