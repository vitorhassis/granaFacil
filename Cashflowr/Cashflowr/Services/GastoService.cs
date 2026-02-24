using GranaFacil.Models;
using GranaFacil.Data.Dtos;
using GranaFacil.Enums.Reserva;
using GranaFacil.Models;
using GranaFacil.Data;
using GranaFacil.Data.Dtos.Gasto;
using GranaFacil.Enums.Gastos;

namespace GranaFacil.Services
{
    public class GastoService
    {
        private readonly GranaFacilContext _context;

        public GastoService (GranaFacilContext context)
        {
            _context = context;
        }

        public void Criar(CreateGastoDto gastoDto, int idUsuario)
        {
            if (gastoDto.Categoria == Categorias.ValorNaoDefinido)
            {
                throw new ArgumentException("Categoria de Saida não pode ser vazio.");
            }

            if (gastoDto.Valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            if (gastoDto.FormaDePagamento == FormaDePagamento.ValorNaoDefinido)
            {
                throw new ArgumentException("Tipo de pagamento inválido.");
            }

            if (gastoDto.DataReferencia > DateTime.Today)
            {
                throw new ArgumentException("Data do gasto inválida");
            }

            var gasto = new Gasto
            {
                IdUsuario = idUsuario,
                Categoria = gastoDto.Categoria,
                FormaDePagamento = gastoDto.FormaDePagamento,
                Valor = gastoDto.Valor,
                DataReferencia = gastoDto.DataReferencia,
                DataCriacao = DateTime.UtcNow,
                IsEssencial = gastoDto.IsEssencial
            };

            _context.Gastos.Add(gasto);
            _context.SaveChanges();
        }

        public List<ReadGastoDto> ListarGastoPorUsuario(int idUsuario, int mes, int ano)
        {

            if (mes < 1 || mes > 12)
                throw new ArgumentException("Mês inválido.");

            if (ano < 2000 || ano > DateTime.Today.Year + 5)
                throw new ArgumentException("Ano inválido.");

            return _context.Gastos
                .Where(g => g.IdUsuario == idUsuario && g.DataReferencia.Month == mes && g.DataReferencia.Year == ano)
                .Select(r => new ReadGastoDto
                {
                    Id = r.Id,
                    Categoria = r.Categoria,
                    FormaDePagamento = r.FormaDePagamento,
                    Valor = r.Valor,
                    DataReferencia = r.DataReferencia,
                    IsEssencial = r.IsEssencial,
                }).ToList();
        }

        public void Alterar(UpdateGastoDto gastoDto, int idUsuario, int idGasto)
        {
            var gasto = _context.Gastos.FirstOrDefault(r => r.Id == idGasto && r.IdUsuario == idUsuario);

            if (gasto == null)
            {
                throw new Exception("Gasto não encontrado.");
            }


            if (gastoDto.Categoria == Categorias.ValorNaoDefinido)
            {
                throw new ArgumentException("Categoria inválida.");
            }

            if (gastoDto.Valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            if (gastoDto.FormaDePagamento == FormaDePagamento.ValorNaoDefinido)
            {
                throw new ArgumentException("Forma de pagamento inválida.");
            }

            if (gastoDto.DataReferencia > DateTime.Today)
            {
                throw new ArgumentException("Data do gasto inválida.");
            }

            gasto.Categoria = gastoDto.Categoria;
            gasto.FormaDePagamento = gastoDto.FormaDePagamento;
            gasto.Valor = gastoDto.Valor;
            gasto.DataReferencia = gastoDto.DataReferencia;
            gasto.IsEssencial = gastoDto.IsEssencial;

            _context.SaveChanges();
        }

        public void Deletar(int idUsuario,int idGasto)
        {
            var gasto = _context.Gastos.FirstOrDefault(g => g.Id == idGasto && g.IdUsuario == idUsuario);

            if (gasto == null)
            {
                throw new ArgumentException("Gasto não encontrado.");
            }

            _context.Gastos.Remove(gasto);
            _context.SaveChanges();
        }
    }
}
