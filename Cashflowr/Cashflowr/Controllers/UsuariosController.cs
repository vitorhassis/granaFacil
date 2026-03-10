using GranaFacil.Data.Dtos.Usuario;
using GranaFacil.Services;
using Microsoft.AspNetCore.Mvc;

namespace GranaFacil.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuariosController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar ([FromBody] RegisterUsuarioDto userDto)
        {
            _service.Criar(userDto);
            return Ok();
        }

        [HttpGet("email")]
        public IActionResult BuscarPorEmail([FromQuery] string email)
        {
            var user = _service.BuscarPorEmail(email);

            return Ok(user);
        }
    }
}
