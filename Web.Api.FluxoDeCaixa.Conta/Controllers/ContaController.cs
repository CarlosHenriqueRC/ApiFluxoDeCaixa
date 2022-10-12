using Microsoft.AspNetCore.Mvc;
using Web.Api.FluxoDeCaixa.Conta.ServicosDeAplicacao.Interfaces;
using VOs=Web.Api.FluxoDeCaixa.Conta.Dominio.VOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.FluxoDeCaixa.Conta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {

        private readonly IConta _contaDeServicosDeAplicacao;

        public ContaController(IConta contaDeServicosDeAplicacao)
        {
            _contaDeServicosDeAplicacao = contaDeServicosDeAplicacao;
        }

        // GET: api/<ContaController>
        [HttpGet("Listar")]
        public IActionResult Get(int ultimoIdPaginaAnterior, int quantidadeDeRegistrosPorPagina)
        {
            try { 
                var retorno =  _contaDeServicosDeAplicacao.Listar(ultimoIdPaginaAnterior, quantidadeDeRegistrosPorPagina);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         }

        // GET api/<ContaController>/5
        [HttpGet("Obter/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var retorno = _contaDeServicosDeAplicacao.Consultar(id);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            // POST api/<ContaController>
        [HttpPost("Adicionar")]
        public IActionResult Post(VOs.Conta conta)
        {

            try { 
                var retorno = _contaDeServicosDeAplicacao.Adicionar(conta);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ContaController>/5
        [HttpPut("Alterar")]
        public IActionResult Put(VOs.Conta conta)
        {
            try { 
                var retorno = _contaDeServicosDeAplicacao.Alterar(conta);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
