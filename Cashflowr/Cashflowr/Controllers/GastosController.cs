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
        public IActionResult Criar(int idUsuario, [FromBody] CreateGastoDto gastoDto)
        {
            var gasto = _service.Criar(gastoDto, idUsuario);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idGasto = gasto.Id },
                gasto
                );
        }

        [HttpGet]
        public IActionResult Listar(int idUsuario, int mes, int ano)
        {
            var gastos = _service.ListarGastoPorUsuarioEMes(idUsuario, mes, ano);
            return Ok(gastos); //200 = Ok.
        }

        [HttpGet("{idGasto}")]
        public IActionResult BuscarPorId(int idGasto, int idUsuario)
        {
            var gasto = _service.BuscarPorId(idGasto, idUsuario);

            if (gasto == null)
            {
                return NotFound();
            }
            return Ok(gasto);
        }

        [HttpPut("{idGasto}")] 
        public IActionResult Alterar(int idGasto, int idUsuario, [FromBody] UpdateGastoDto gastoDto)
        {
            _service.Alterar(gastoDto, idUsuario, idGasto);
            return NoContent(); //204 = alteração feita com sucesso.
        }

        [HttpDelete("{idGasto}")]
        public IActionResult Remover(int idGasto, int idUsuario)
        {
            _service.Deletar(idGasto, idUsuario);
            return NoContent();
        }
    }
}
