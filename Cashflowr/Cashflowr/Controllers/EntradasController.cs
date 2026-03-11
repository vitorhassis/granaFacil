
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
        public IActionResult Criar (int UsuarioId, [FromBody] CreateEntradaDto dto)
        {
            var entrada = _service.Criar(dto, UsuarioId);
            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idEntrada = entrada.Id },
                entrada
                );
        }

        [HttpGet]
        public IActionResult Listar (int UsuarioId, int mes, int ano)
        {
            var entradas = _service.ListarPorUsuarioEMes(UsuarioId, mes, ano);
            return Ok(entradas);
        }

        [HttpGet("{idEntrada}")]
        public IActionResult BuscarPorId (int idEntrada, int UsuarioId)
        {
            var entrada = _service.BuscarPorId(idEntrada, UsuarioId);

            if(entrada == null)
            {
                return NotFound();
            }
            return Ok(entrada);
        }

        [HttpPut("{idEntrada}")]
        public IActionResult Alterar (int idEntrada, int UsuarioId, [FromBody] UpdateEntradaDto entradaDto)
        {
            _service.Alterar(idEntrada, UsuarioId, entradaDto);
            return NoContent();
        }

        [HttpDelete("{idEntrada}")]
        public IActionResult Remover(int idEntrada, int UsuarioId)
        {
            _service.Deletar(idEntrada, UsuarioId);
            return NoContent();
        }


    }
}
