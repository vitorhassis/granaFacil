using GranaFacil.Data.Dtos.Meta;
using GranaFacil.Data.Dtos.Reserva;
using GranaFacil.Models;
using GranaFacil.Services;
using Microsoft.AspNetCore.Mvc;

namespace GranaFacil.Controllers
{
    [ApiController]
    [Route("api/reservas")]
    public class ReservasController : ControllerBase
    {
        private readonly ReservaService _service;

        public ReservasController(ReservaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar(int UsuarioId, [FromBody] CreateReservaDto reservaDto)
        {
            var reserva = _service.Criar(reservaDto, UsuarioId);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idReserva = reserva.Id },
                reserva
                );
        }

        [HttpGet]
        public IActionResult Listar(int UsuarioId, int mes, int ano)
        {
            var reservas = _service.ListarReservaPorUsuario(UsuarioId, mes, ano);
            return Ok(reservas);
        }

        [HttpGet("{idReserva}")]
        public IActionResult BuscarPorId(int idReserva, int UsuarioId)
        {
            var reserva = _service.BuscarPorId(idReserva, UsuarioId);

            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPut("{idReserva}")]
        public IActionResult Alterar(int idReserva, int UsuarioId, [FromBody] UpdateReservaDto reservaDto)
        {
            _service.Alterar(reservaDto, UsuarioId, idReserva);
            return NoContent(); //204 = alteração feita com sucesso.
        }

        [HttpDelete("{idReserva}")]
        public IActionResult Remover(int idReserva, int UsuarioId)
        {
            _service.Deletar(idReserva, UsuarioId);
            return NoContent();
        }
    }
}
