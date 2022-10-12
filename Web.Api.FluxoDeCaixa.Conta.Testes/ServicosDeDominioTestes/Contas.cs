using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.FluxoDeCaixa.Conta.Dominio.Exceptions;
using Xunit;
using Entidade = Web.Api.FluxoDeCaixa.Conta.Dominio.Entidades;
using ServicosDeDominio=Web.Api.FluxoDeCaixa.Conta.Dominio.Servicos.Interfaces;

namespace Web.Api.FluxoDeCaixa.Conta.Testes.ServicosDeDominioTestes
{
    public class Contas
    {
        private readonly ServicosDeDominio.IContas _contasDeServicosDeDominio;

        public Contas()
        {
            _contasDeServicosDeDominio = new Web.Api.FluxoDeCaixa.Conta.Dominio.Servicos.Contas();
        }


        [Fact]
        public void verificarSeContaExiste_ContaNaoExiste_ListaVazia()
        {
            IList<Entidade.Conta> listaDeContasDeDominio = new List<Entidade.Conta>();

            Entidade.Conta contaDeDominio = new() { id = 1, descricao = "Lapis", ativa = true };

            _contasDeServicosDeDominio.verificarSeContaExiste(contaDeDominio, listaDeContasDeDominio);

            Assert.True(true);

        }

        [Fact]
        public void verificarSeContaExiste_ContaExiste_EditarConta()
        {
            IList<Entidade.Conta> listaDeContasDeDominio = new List<Entidade.Conta>()
            {
                new Entidade.Conta() { id = 1, descricao = "Lapis", ativa = true }
            };

            Entidade.Conta contaDeDominio = new() { id = 1, descricao = "Lapis", ativa = false };

            _contasDeServicosDeDominio.verificarSeContaExiste(contaDeDominio, listaDeContasDeDominio);

            Assert.True(true);

        }

        [Fact]
        public void verificarSeContaExiste_GeraExcecao_ListaComMaisDeUmElemento()
        {
            IList<Entidade.Conta> listaDeContasDeDominio = new List<Entidade.Conta>() {
             new Entidade.Conta() {id = 1, descricao = "Lapis",ativa = true},
             new Entidade.Conta() {id = 2, descricao = "Caneta",ativa = true},
            };

            Entidade.Conta contaDeDominio = new() { id = 3, descricao = "Lapiseira", ativa = true };

            Assert.Throws<ContaException>(() => _contasDeServicosDeDominio.verificarSeContaExiste(contaDeDominio, listaDeContasDeDominio));
        }

        [Fact]
        public void verificarSeContaExiste_GeraExcecao_IdsDifererentes()
        {
            IList<Entidade.Conta> listaDeContasDeDominio = new List<Entidade.Conta>() {
             new Entidade.Conta() {id = 1, descricao = "Lapis",ativa = true},
             new Entidade.Conta() {id = 2, descricao = "Caneta",ativa = true},
            };

            Entidade.Conta contaDeDominio = new() { id = 3, descricao = "Lapiseira", ativa = true };

            Assert.Throws<ContaException>(() => _contasDeServicosDeDominio.verificarSeContaExiste(contaDeDominio, listaDeContasDeDominio));
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
