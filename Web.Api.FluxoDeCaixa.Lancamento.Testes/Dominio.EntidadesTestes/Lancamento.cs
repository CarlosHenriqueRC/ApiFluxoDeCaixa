using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.FluxoDeCaixa.Lancamento.Dominio.Exceptions;
using Xunit;
using Entidade = Web.Api.FluxoDeCaixa.Lancamento.Dominio.Entidades;

namespace Web.Api.FluxoDeCaixa.Lancamento.Testes.Dominio.EntidadesTestes
{
    public class Lancamento
    {
        [Fact]
        public void Validar_OK()
        {
            Entidade.Lancamento lancamento = new()
            {
                id = 1,
                valor=10,
                tipo="C",
                data=DateTime.Now,
                conta = new Entidade.Conta() { id=1,descricao="Caneta",ativa=true}
            };

            lancamento.Validar();

            Assert.True(true);
        }

        [Fact]
        public void Validar_GerarExcecao_ValorInvalido()
        {
            Entidade.Lancamento lancamento = new()
            {
                id = 1,
                valor =-10,
                tipo = "C",
                data = DateTime.Now,
                conta = new Entidade.Conta() { id = 1, descricao = "Caneta", ativa = true }
            };

            Assert.Throws<LancamentoException>(() => lancamento.Validar());
        }

        [Fact]
        public void Validar_GerarExcecao_TipoInvalido()
        {
            Entidade.Lancamento lancamento = new()
            {
                id = 1,
                valor = 10,
                tipo = "S",
                data = DateTime.Now,
                conta = new Entidade.Conta() { id = 1, descricao = "Caneta", ativa = true }
            };

            Assert.Throws<LancamentoException>(() => lancamento.Validar());
        }

        [Fact]
        public void Validar_GerarExcecao_ContaInvalidaDefault()
        {
            Entidade.Lancamento lancamento = new()
            {
                id = 1,
                valor = 10,
                tipo = "D",
                data = DateTime.Now,
                conta = default,
            };

            Assert.Throws<LancamentoException>(() => lancamento.Validar());
        }

        [Fact]
        public void Validar_GerarExcecao_ContaInvalidaNull()
        {
            Entidade.Lancamento lancamento = new()
            {
                id = 1,
                valor = 10,
                tipo = "D",
                data = DateTime.Now,
                conta = null,
            };

            Assert.Throws<LancamentoException>(() => lancamento.Validar());
        }

        [Fact]
        public void GerarLancamentoDeEstorno_OK()
        {
            Entidade.Lancamento lancamento = new()
            {
                id = 1,
                valor = -10,
                tipo = "C",
                data = DateTime.Now,
                conta = new Entidade.Conta() { id = 1, descricao = "Caneta", ativa = true }
            };

            Entidade.Lancamento lancamentoDeEstorno = lancamento.GerarLancamentoDeEstorno();

            Assert.True(lancamentoDeEstorno.id == lancamento.id);
            Assert.True(lancamentoDeEstorno.tipo == (lancamento.tipo=="C" ?"D":"C"));
            Assert.True(lancamentoDeEstorno.data == lancamento.data);
            Assert.True(lancamentoDeEstorno.conta.id == lancamento.conta.id);
            Assert.True(lancamentoDeEstorno.conta.descricao == lancamento.conta.descricao);
            Assert.True(lancamentoDeEstorno.conta.ativa == lancamento.conta.ativa);
            Assert.True(lancamentoDeEstorno.valor == lancamento.valor);
        }
    }
}
