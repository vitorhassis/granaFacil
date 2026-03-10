
using GranaFacil.Data.Dtos.Entrada;
using GranaFacil.Services;
using Microsoft.AspNetCore.Mvc;

namespace GranaFacil.Controllers
{
    [ApiController]
    [Route("api/entradas")]
    public class EntradasController : ControllerBase
    {
        private readonly EntradaService _service;

        public EntradasController (EntradaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar (int idUsuario, [FromBody] CreateEntradaDto dto)
        {
            var entrada = _service.Criar(dto, idUsuario);
            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idEntrada = entrada.Id },
                entrada
                );
        }

        [HttpGet]
        public IActionResult Listar (int idUsuario, int mes, int ano)
        {
            var entradas = _service.ListarPorUsuarioEMes(idUsuario, mes, ano);
            return Ok(entradas);
        }

        [HttpGet("{idEntrada}")]
        public IActionResult BuscarPorId (int idEntrada, int idUsuario)
        {
            var entrada = _service.BuscarPorId(idEntrada, idUsuario);

            if(entrada == null)
            {
                return NotFound();
            }
            return Ok(entrada);
        }

        [HttpPut("{idEntrada}")]
        public IActionResult Alterar (int idEntrada, int idUsuario, [FromBody] UpdateEntradaDto entradaDto)
        {
            _service.Alterar(idEntrada, idUsuario, entradaDto);
            return NoContent();
        }

        [HttpDelete("{idEntrada}")]
        public IActionResult Remover(int idEntrada, int idUsuario)
        {
            _service.Deletar(idEntrada, idUsuario);
            return NoContent();
        }


    }
}
