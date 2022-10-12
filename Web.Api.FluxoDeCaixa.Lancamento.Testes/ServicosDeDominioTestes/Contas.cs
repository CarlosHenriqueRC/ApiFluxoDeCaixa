using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Exceptions;
using Xunit;
using Entidade = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;
using ServicosDeDominio=Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Interfaces;

namespace Web.Api.FluxoDeCaixa.Lancamento.Testes.ServicosDeDominioTestes
{
    public class Contas
    {
        private readonly ServicosDeDominio.IContas _contasDeServicosDeDominio;

        public Contas()
        {
            _contasDeServicosDeDominio = new Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Contas();
        }

        [Fact]
        public void verificarSeContaNaoExiste_GeraExcecao()
        {
            Assert.Throws<ContaException>(() => _contasDeServicosDeDominio.verificarSeContaNaoExiste(default));
        }

        [Fact]
        public void verificarSeContaNaoExiste_ContaExistente()
        {

            _contasDeServicosDeDominio.verificarSeContaNaoExiste(new Entidade.Conta() { id = 1, descricao = "Caneta", ativa = true });

            Assert.True(true);
        }
    }
}
