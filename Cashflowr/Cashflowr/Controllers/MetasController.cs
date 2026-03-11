using GranaFacil.Data.Dtos.Meta;
using GranaFacil.Services;
using Microsoft.AspNetCore.Mvc;

namespace GranaFacil.Controllers
{
    [ApiController]
    [Route("api/metas")]
    public class MetasController : ControllerBase
    {
        private readonly MetaService _service;

        public MetasController(MetaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar(int UsuarioId, [FromBody] CreateMetaDto metaDto)
        {
            var meta = _service.Criar(metaDto, UsuarioId);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idMeta = meta.Id },
                meta
                );
        }

        [HttpGet]
        public IActionResult Listar(int UsuarioId, int mes, int ano)
        {
            var metas = _service.ListarMetaPorUsuario(UsuarioId, mes, ano);
            return Ok(metas); 
        }

        [HttpGet("{idMeta}")]
        public IActionResult BuscarPorId(int idMeta, int UsuarioId)
        {
            var meta = _service.BuscarPorId(idMeta, UsuarioId);

            if (meta == null)
            {
                return NotFound();
            }
            return Ok(meta);
        }

        [HttpPut("{idMeta}")]
        public IActionResult Alterar(int idMeta, int UsuarioId, [FromBody] UpdateMetaDto metaDto)
        {
            _service.Alterar(idMeta, UsuarioId, metaDto);
            return NoContent(); //204 = alteração feita com sucesso.
        }

        [HttpDelete("{idMeta}")]
        public IActionResult Remover(int idMeta, int UsuarioId)
        {
            _service.Deletar(idMeta, UsuarioId);
            return NoContent();
        }
    }
}
