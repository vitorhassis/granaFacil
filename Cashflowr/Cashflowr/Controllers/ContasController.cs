using GranaFacil.Data.Dtos.Conta;
using GranaFacil.Services;
using Microsoft.AspNetCore.Mvc;

namespace GranaFacil.Controllers
{
    [ApiController]
    [Route("api/contas")]
    public class ContasController : ControllerBase
    {
        private readonly ContaService _service;

        public ContasController(ContaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar (int UsuarioId, [FromBody] CreateContaDto contaDto)
        {
            var conta = _service.Criar(contaDto, UsuarioId);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idConta = conta.Id },
                conta
                );
        }

        [HttpGet]
        public IActionResult Listar (int UsuarioId, int mes, int ano)
        {
            var contas = _service.ListarPorUsuarioEMes(UsuarioId, mes, ano);
            return Ok(contas); //200 = Ok.
        }

        [HttpGet("{idConta}")] //idConta vem na rota
        public IActionResult BuscarPorId(int idConta, int UsuarioId)
        {
            var conta = _service.BuscarPorId(idConta, UsuarioId);

            if(conta==null)
            {
                return NotFound();
            }
            return Ok(conta);
        }

        [HttpPut("{idConta}")] //id do recurso é passado via rota
        public IActionResult Alterar (int idConta, int UsuarioId, [FromBody] UpdateContaDto contaDto)
        {
            _service.Alterar(idConta, UsuarioId, contaDto);
            return NoContent(); //204 = alteração feita com sucesso.
        }

        [HttpDelete("{idConta}")]
        public IActionResult Remover (int idConta, int UsuarioId)
        {
            _service.Remover(idConta, UsuarioId);
            return NoContent();
        }

        [HttpPatch("{idConta}")] 
        public IActionResult Pagar (int idConta, int UsuarioId)
        {
            _service.Pagar(idConta, UsuarioId);
            return NoContent();
        }
    }
}
