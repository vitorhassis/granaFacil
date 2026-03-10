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
        public IActionResult Criar(int idUsuario, [FromBody] CreateMetaDto metaDto)
        {
            var meta = _service.Criar(metaDto, idUsuario);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idMeta = meta.Id },
                meta
                );
        }

        [HttpGet]
        public IActionResult Listar(int idUsuario, int mes, int ano)
        {
            var metas = _service.ListarMetaPorUsuario(idUsuario, mes, ano);
            return Ok(metas); 
        }

        [HttpGet("{idMeta}")]
        public IActionResult BuscarPorId(int idMeta, int idUsuario)
        {
            var meta = _service.BuscarPorId(idMeta, idUsuario);

            if (meta == null)
            {
                return NotFound();
            }
            return Ok(meta);
        }

        [HttpPut("{idMeta}")]
        public IActionResult Alterar(int idMeta, int idUsuario, [FromBody] UpdateMetaDto metaDto)
        {
            _service.Alterar(idMeta, idUsuario, metaDto);
            return NoContent(); //204 = alteração feita com sucesso.
        }

        [HttpDelete("{idMeta}")]
        public IActionResult Remover(int idMeta, int idUsuario)
        {
            _service.Deletar(idMeta, idUsuario);
            return NoContent();
        }
    }
}
