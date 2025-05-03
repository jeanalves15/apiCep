using apiCep.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace apiCep.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnderecoController(IEnderecoServices enderecoServices) : ControllerBase
    {
        public readonly IEnderecoServices _enderecoServices = enderecoServices;

        [HttpGet("buscar/{cep}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarEndereço([FromRoute] string cep)
        {
            var response = await _enderecoServices.BuscarEndereco(cep);
            if(response.CodigoHttp == HttpStatusCode.OK)
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
