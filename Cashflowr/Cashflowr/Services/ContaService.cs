using GranaFacil.Data.Dtos.Conta;
using GranaFacil.Models;
using GranaFacil.Repositories;

namespace GranaFacil.Services
{
    public class ContaService
    {
        private readonly IContaRepository _repository;
        public ContaService(IContaRepository repository)
        {
            _repository = repository;
        }

        public Conta Criar(CreateContaDto contaDto, int UsuarioId)
        {
            if (contaDto.DataVencimento < DateTime.Today.AddYears(-1) || contaDto.DataVencimento > DateTime.Today.AddYears(5))
            {
                throw new ArgumentException("Data de vencimento inválida.");
            }

            if (contaDto.Valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            var valorPlanejado = contaDto.ValorPlanejado ?? contaDto.Valor;
            var valor = contaDto.Valor ?? 0;

            if (valorPlanejado < 0) 
            {
                throw new ArgumentException("Valor planejado não pode ser negativo.");
            }

            var conta = new Conta
            {
                UsuarioId = UsuarioId,
                Nome = contaDto.Nome,
                Valor = valor,
                DataVencimento = contaDto.DataVencimento,
                ValorPlanejado = valorPlanejado,
                DataPagamento = null, 
            };

            _repository.Adicionar(conta);
            _repository.Salvar();
            return conta;
        }

        public List<ReadContaDto> ListarPorUsuarioEMes(int UsuarioId, int mes, int ano) 
        { 

            if (mes < 01 || mes > 12)
                throw new ArgumentException("Mês inválido.");

            if (ano < 2000 || ano > DateTime.Today.Year + 5)
                throw new ArgumentException("Ano inválido.");

            var conta = _repository.ListarPorUsuarioEMes(UsuarioId, mes, ano);

            return conta.Select(c => new ReadContaDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Valor = c.Valor,
                ValorPlanejado = c.ValorPlanejado,
                DataVencimento = c.DataVencimento,
                DataPagamento = c.DataPagamento,
                IsPago = c.IsPago
            }).ToList();

        }

        public void Alterar(int idConta, int UsuarioId, UpdateContaDto contaDto)
        {
            var conta = _repository.BuscarPorId(idConta, UsuarioId);

            if (conta == null)
            {
                throw new ArgumentException("Conta não encontrada.");
            }

            if (contaDto.DataVencimento < DateTime.Today.AddYears(-1) || contaDto.DataVencimento > DateTime.Today.AddYears(5))
            {
                throw new ArgumentException("Data de vencimento inválida.");
            }

            if (contaDto.Valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            var valorPlanejado = contaDto.ValorPlanejado ?? contaDto.Valor;

            if (valorPlanejado < 0)
            {
                throw new ArgumentException("Valor planejado não pode ser negativo.");
            }

            conta.Nome = contaDto.Nome;
            conta.Valor = contaDto.Valor;
            conta.ValorPlanejado = valorPlanejado;
            conta.DataVencimento = contaDto.DataVencimento;

            _repository.Salvar();
        }

        public void Remover(int idConta, int UsuarioId)
        {
            var conta = _repository.BuscarPorId(idConta, UsuarioId);

            if (conta == null)
            {
                throw new ArgumentException("Conta não encontrada.");
            }

            _repository.Remover(conta);
            _repository.Salvar();
        }

        public void Pagar(int idConta, int UsuarioId)
        {
            var conta = _repository.BuscarPorId(idConta, UsuarioId);

            if (conta == null)
            {
                throw new ArgumentException("Conta não encontrada.");
            }

            if (conta.IsPago)
            {
                throw new InvalidOperationException("Conta já está registrada como paga.");
            }

            conta.DataPagamento = DateTime.Now;
            conta.IsPago = true;

            _repository.Salvar();
        }

        public Conta? BuscarPorId(int idConta, int UsuarioId)
        {
            var conta = _repository.BuscarPorId(idConta, UsuarioId);
            return conta;
        }

    }
}
