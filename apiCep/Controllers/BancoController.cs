using apiCep.Interfaces;
using apiCep.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace apiCep.Controllers
{
    [ApiController]
    [Route("api/v1/(controller)")]
    public class BancoController : Controller
    {
        private readonly IBancoServices _bancoServices;

        public BancoController(IBancoServices bancoServices)
        {
            _bancoServices = bancoServices;
        }

        [HttpGet("buscar/todos")]
      
        public async Task<IActionResult> BuscarTodos()
        {
            var response = await _bancoServices.BuscarTodos();
            if(response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }
        [HttpGet("buscar/{codigoBanco}")]

        public async Task<IActionResult> Buscar(string codigoBanco)
        {
            var response = await _bancoServices.BuscarBanco(codigoBanco);
            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            else
            {
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
            }
        }
    }
}
