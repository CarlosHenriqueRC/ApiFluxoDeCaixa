using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.FluxoDeCaixa.Relatorios.Dominio.Repositorios.Interfaces;

namespace Web.Api.FluxoDeCaixa.Relatorios.Testes.Auxiliares.Repositorios
{
    internal class Lancamento : ILancamentos
    {
        public IList<Dominio.VOs.Lancamento> ObterDadosParaRelatorioConsolidado(DateTime datainicio, DateTime datafinal)
        {
            throw new NotImplementedException();
        }
    }
}
