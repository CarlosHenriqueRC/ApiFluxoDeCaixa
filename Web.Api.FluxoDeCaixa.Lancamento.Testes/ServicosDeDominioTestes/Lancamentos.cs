using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Exceptions;
using Xunit;
using Entidade = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;
using ServicosDeDominio = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Interfaces;

namespace Web.Api.FluxoDeCaixa.Lancamento.Testes.ServicosDeDominioTestes
{
    public class Lancamentos
    {
        private readonly ServicosDeDominio.ILancamentos _LancamentosDeServicosDeDominio;

        public Lancamentos()
        {
            _LancamentosDeServicosDeDominio = new Web.Api.FluxoDeCaixa.Lancamento.Dominio.Servicos.Lancamentos();
        }

        [Fact]
        public void verificarSeLancamentoExiste_GeraExcecao()
        {
            Assert.Throws<LancamentoException>(() => _LancamentosDeServicosDeDominio.verificarSeLancamentoExiste(default));
        }

        [Fact]
        public void verificarSeLancamentoExiste_LancamentoExistente()
        {

            _LancamentosDeServicosDeDominio.verificarSeLancamentoExiste(new Entidade.Lancamento() { id = 1, valor = 10,tipo="C",data=DateTime.Parse("02/10/2022"),conta= new Entidade.Conta() { id=1,descricao="Pente",ativa=true} });

            Assert.True(true);
        }
    }
}
