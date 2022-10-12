using Microsoft.AspNetCore.Mvc;
using Web.Api.FluxoDeCaixa.Lancamento.ServicosDeAplicacao.Interfaces;
using VOs = Web.Api.FluxoDeCaixa.Lancamento.Dominio.VOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.FluxoDeCaixa.Lancamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {

        private readonly ILancamento _lancamentoServicosDeAplicacao;

        public LancamentoController(ILancamento lancamentoServicosDeAplicacao)
        {
            _lancamentoServicosDeAplicacao = lancamentoServicosDeAplicacao;
        }
        //GET: api/<LancamentoController>
        [HttpGet("Consultar")]
        public IActionResult Get(DateTime inicio, DateTime final)
        {
            try
            {
                var retorno = _lancamentoServicosDeAplicacao.RetornarLancamentosEntrePeriodo(inicio, final);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //POST api/<LancamentoController>
        [HttpPost("Efetuar")]
        public IActionResult Post(VOs.DadosParaEfetuarLancamento lancamento)
        {

            try {

                _lancamentoServicosDeAplicacao.Efetuar(lancamento);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT api/<LancamentoController>/5
        [HttpPut("Estornar/{id}")]
        public IActionResult Put(int id)
        {
            try
            {
                _lancamentoServicosDeAplicacao.Estornar(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
