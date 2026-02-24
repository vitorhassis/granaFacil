using GranaFacil.Models;
using GranaFacil.Data;
using GranaFacil.Data.Dtos.Conta;

namespace GranaFacil.Services
{
    public class ContaService
    {
        private readonly GranaFacilContext _context;
        public ContaService(GranaFacilContext context)
        {
            _context = context;
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

            var valorPlanejado = contaDto.ValorPlanejado ?? contaDto.Valor; //se o valor da esquerda for null, usa o valor da direita para definir o valorPlanejado (evita um if e else)

            if (valorPlanejado < 0) //sempre validando a var final que vai ser usada
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

            _context.Contas.Add(conta);
            _context.SaveChanges();
        }

        public List<ReadContasDto> ListarPorUsuarioEMes(int idUsuario, int mes, int ano) 
        { 

            if (mes < 1 || mes > 12)
                throw new ArgumentException("Mês inválido.");

            if (ano < 2000 || ano > DateTime.Today.Year + 5)
                throw new ArgumentException("Ano inválido.");


            return _context.Contas
                .Where(c => c.IdUsuario == idUsuario && c.DataVencimento.Month == mes && c.DataVencimento.Year == ano)
                .Select(c => new ReadContasDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Valor = c.Valor,
                    ValorPlanejado = c.ValorPlanejado,
                    DataVencimento = c.DataVencimento,
                    DataPagamento = c.DataPagamento,
                    IsPago = c.IsPago,

                }).ToList();
        }

        public void Alterar(int idConta, int idUsuario, UpdateContasDto contaDto)
        {
            var conta = _context.Contas.FirstOrDefault(c => c.Id == idConta && c.IdUsuario == idUsuario);

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
            
            _context.SaveChanges();
        }

        public void Deletar(int idConta, int idUsuario)
        {
            var conta = _context.Contas.FirstOrDefault(c => c.Id == idConta && c.IdUsuario == idUsuario);

            if(conta == null)
            {
                throw new ArgumentException("Conta não encontrada.");
            }

            _context.Contas.Remove(conta);
            _context.SaveChanges();
        }

        public void Pagar(int idConta, int idUsuario)
        {
            var conta = _context.Contas.FirstOrDefault(c => c.Id == idConta && c.IdUsuario == idUsuario);

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

            _context.SaveChanges();
        }

    }
}
