using GranaFacil.Data;
using GranaFacil.Data.Dtos.Entrada;
using GranaFacil.Models;

namespace GranaFacil.Services
{
    public class EntradaService
    {
        private readonly GranaFacilContext _context;

        public EntradaService(GranaFacilContext context)
        {
            _context = context;
        }

        public void Criar(CreateEntradaDto entradaDto, int idUsuario)
        {
            if (entradaDto.DataEntrada < DateTime.Today.AddYears(-1) || entradaDto.DataEntrada> DateTime.Today)
            {
                throw new ArgumentException("Data de entrada inválida.");
            }

            if (entradaDto.Valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            var entrada = new Entrada
            {
                IdUsuario = idUsuario,
                Nome = entradaDto.Nome,
                Valor = entradaDto.Valor,
                DataEntrada = entradaDto.DataEntrada,
  
            };

            _context.Entradas.Add(entrada);
            _context.SaveChanges();
        }

        public List<ReadEntradaDto> ListarPorUsuarioEMes (int idUsuario, int mes, int ano)
        {

            if (mes < 1 || mes > 12)
                throw new ArgumentException("Mês inválido.");

            if (ano < 2000 || ano > DateTime.Today.Year + 5)
                throw new ArgumentException("Ano inválido.");


            return _context.Entradas
                .Where(e => e.IdUsuario == idUsuario && e.DataEntrada.Month == mes && e.DataEntrada.Year == ano)
                .Select(e => new ReadEntradaDto
                {
                    Id = e.Id,
                    Nome = e.Nome,
                    Valor = e.Valor,
                    DataEntrada = e.DataEntrada,
                }).ToList();
        }

        public void Alterar(int idEntrada, int idUsuario, UpdateEntradaDto entradaDto)
        {
            var entrada = _context.Entradas.FirstOrDefault(e => e.Id == idEntrada && e.IdUsuario == idUsuario);

            if (entrada == null)
            {
                throw new ArgumentException("Entrada não encontrada.");
            }

            if (entradaDto.DataEntrada < DateTime.Today.AddYears(-1) || entradaDto.DataEntrada > DateTime.Today)
            {
                throw new ArgumentException("Data de entrada inválida.");
            }

            if (entradaDto.Valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }


            entrada.Nome = entradaDto.Nome;
            entrada.Valor = entradaDto.Valor;
            entrada.DataEntrada = entradaDto.DataEntrada;

            _context.SaveChanges();
        }

        public void Deletar(int idEntrada, int idUsuario)
        {
            var entrada = _context.Entradas.FirstOrDefault(c => c.Id == idEntrada && c.IdUsuario == idUsuario);

            if (entrada == null)
            {
                throw new ArgumentException("Entrada não encontrada.");
            }

            _context.Entradas.Remove(entrada);
            _context.SaveChanges();
        }

    }
}
