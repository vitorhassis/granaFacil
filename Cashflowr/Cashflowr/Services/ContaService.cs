using GranaFacil.Data;
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

        public void Criar(CreateContasDto contaDto, int idUsuario)
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

            if (valorPlanejado < 0) 
            {
                throw new ArgumentException("Valor planejado não pode ser negativo.");
            }

            var conta = new Conta
            {
                IdUsuario = idUsuario,
                Nome = contaDto.Nome,
                Valor = contaDto.Valor,
                DataVencimento = contaDto.DataVencimento,
                ValorPlanejado = valorPlanejado,
                DataPagamento = null, 
            };

            _repository.Adicionar(conta);
            _repository.Salvar();
        }

        public List<ReadContasDto> ListarPorUsuarioEMes(int idUsuario, int mes, int ano) 
        { 

            if (mes < 1 || mes > 12)
                throw new ArgumentException("Mês inválido.");

            if (ano < 2000 || ano > DateTime.Today.Year + 5)
                throw new ArgumentException("Ano inválido.");

            var contas = _repository.ListarPorUsuarioEMes(idUsuario, mes, ano);

            return contas.Select(c => new ReadContasDto
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

        public void Alterar(int idConta, int idUsuario, UpdateContasDto contaDto)
        {
            var conta = _repository.BuscarPorId(idConta, idUsuario);

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

        public void Remover(int idConta, int idUsuario)
        {
            var conta = _repository.BuscarPorId(idConta, idUsuario);

            if (conta == null)
            {
                throw new ArgumentException("Conta não encontrada.");
            }

            _repository.Remover(conta);
            _repository.Salvar();


        }

        public void Pagar(int idConta, int idUsuario)
        {
            var conta = _repository.BuscarPorId(idConta, idUsuario);

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

    }
}
