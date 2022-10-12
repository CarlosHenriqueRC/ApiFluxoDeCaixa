using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.FluxoDeCaixa.Conta.Dominio.Exceptions;
using Xunit;
using Entidade=Web.Api.FluxoDeCaixa.Conta.Dominio.Entidades;

namespace Web.Api.FluxoDeCaixa.Conta.Testes.Dominio.Entidades.Testes
{
    public class Conta
    {
        [Fact]
        public void Validar_OK()
        {
            Entidade.Conta conta = new()
            {
                id = 1,
                descricao = "Lapis",
                ativa = true,
            };

            conta.Validar();

            Assert.True(true);
        }

        [Fact]
        public void Validar_GerarExcecao()
        {
            Entidade.Conta conta = new()
            {
                id = 1,
                descricao = "",
                ativa = true,
            };

            Assert.Throws<ContaException>(()=>conta.Validar());
        }
    }
}
