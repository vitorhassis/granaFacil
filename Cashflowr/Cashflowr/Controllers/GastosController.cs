using GranaFacil.Data.Dtos.Gasto;
using GranaFacil.Services;
using Microsoft.AspNetCore.Mvc;

namespace GranaFacil.Controllers
{
    [ApiController]
    [Route("api/gastos")]
    public class GastosController : ControllerBase
    {
        private readonly GastoService _service;

        public GastosController(GastoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar(int UsuarioId, [FromBody] CreateGastoDto gastoDto)
        {
            var gasto = _service.Criar(gastoDto, UsuarioId);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idGasto = gasto.Id },
                gasto
                );
        }

        [HttpGet]
        public IActionResult Listar(int UsuarioId, int mes, int ano)
        {
            var gastos = _service.ListarGastoPorUsuarioEMes(UsuarioId, mes, ano);
            return Ok(gastos); //200 = Ok.
        }

        [HttpGet("{idGasto}")]
        public IActionResult BuscarPorId(int idGasto, int UsuarioId)
        {
            var gasto = _service.BuscarPorId(idGasto, UsuarioId);

            if (gasto == null)
            {
                return NotFound();
            }
            return Ok(gasto);
        }

        [HttpPut("{idGasto}")] 
        public IActionResult Alterar(int idGasto, int UsuarioId, [FromBody] UpdateGastoDto gastoDto)
        {
            _service.Alterar(gastoDto, UsuarioId, idGasto);
            return NoContent(); //204 = alteração feita com sucesso.
        }

        [HttpDelete("{idGasto}")]
        public IActionResult Remover(int idGasto, int UsuarioId)
        {
            _service.Deletar(idGasto, UsuarioId);
            return NoContent();
        }
    }
}
