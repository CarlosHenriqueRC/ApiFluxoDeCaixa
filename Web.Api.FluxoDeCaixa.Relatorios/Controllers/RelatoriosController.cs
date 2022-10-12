using Microsoft.AspNetCore.Mvc;
using Web.Api.FluxoDeCaixa.Relatorios.ServicosDeAplicacao.Interfaces;
using VOs=Web.Api.FluxoDeCaixa.Relatorios.Dominio.VOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.FluxoDeCaixa.Relatorios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {

        private readonly ILancamento _lancamentoDeServicosDeAplicacao;

        public RelatoriosController(ILancamento lancamentoDaServicosDeAplicacao)
        {
            _lancamentoDeServicosDeAplicacao = lancamentoDaServicosDeAplicacao;
        }

        // GET: api/<RElatoriosController>
        [HttpGet("ObterDadosParaRelatorioConsolidado")]
        public IActionResult Get(DateTime inicio, DateTime final)
        {
            try
            {
                var retorno =  _lancamentoDeServicosDeAplicacao.ObterDadosParaRelatorioConsolidado(inicio, final);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
