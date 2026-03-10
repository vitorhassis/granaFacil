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
        public IActionResult Criar (int idUsuario, [FromBody] CreateContasDto contaDto)
        {
            var conta = _service.Criar(contaDto, idUsuario);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { idConta = conta.Id },
                conta
                );
        }

        [HttpGet]
        public IActionResult Listar (int idUsuario, int mes, int ano)
        {
            var contas = _service.ListarPorUsuarioEMes(idUsuario, mes, ano);
            return Ok(contas); //200 = Ok.
        }

        [HttpGet("{idConta}")]
        public IActionResult BuscarPorId(int idConta, int idUsuario)
        {
            var conta = _service.BuscarPorId(idConta, idUsuario);

            if(conta==null)
            {
                return NotFound();
            }
            return Ok(conta);
        }

        [HttpPut("{idConta}")] //implemento isso quando o endpoint precisa receber um id pela rota. só olhar no método do service. se no parametro, ele recebe idConta, poe aqui
        public IActionResult Alterar (int idConta, int idUsuario, [FromBody] UpdateContasDto contaDto)
        {
            _service.Alterar(idConta, idUsuario, contaDto);
            return NoContent(); //204 = alteração feita com sucesso.
        }

        [HttpDelete("{idConta}")]
        public IActionResult Remover (int idConta, int idUsuario)
        {
            _service.Remover(idConta, idUsuario);
            return NoContent();
        }

        [HttpPatch("{idConta}")] 
        public IActionResult Pagar (int idConta, int idUsuario)
        {
            _service.Pagar(idConta, idUsuario);
            return NoContent();
        }
    }
}
