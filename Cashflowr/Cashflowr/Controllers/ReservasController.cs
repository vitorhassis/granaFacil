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
        public IActionResult Criar(int idUsuario, [FromBody] CreateReservaDto reservaDto)
        {
            var reserva = _service.Criar(reservaDto, idUsuario);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idReserva = reserva.Id },
                reserva
                );
        }

        [HttpGet]
        public IActionResult Listar(int idUsuario, int mes, int ano)
        {
            var reservas = _service.ListarReservaPorUsuario(idUsuario, mes, ano);
            return Ok(reservas);
        }

        [HttpGet("{idReserva}")]
        public IActionResult BuscarPorId(int idReserva, int idUsuario)
        {
            var reserva = _service.BuscarPorId(idReserva, idUsuario);

            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPut("{idReserva}")]
        public IActionResult Alterar(int idReserva, int idUsuario, [FromBody] UpdateReservaDto reservaDto)
        {
            _service.Alterar(reservaDto, idUsuario, idReserva);
            return NoContent(); //204 = alteração feita com sucesso.
        }

        [HttpDelete("{idReserva}")]
        public IActionResult Remover(int idReserva, int idUsuario)
        {
            _service.Deletar(idReserva, idUsuario);
            return NoContent();
        }
    }
}
