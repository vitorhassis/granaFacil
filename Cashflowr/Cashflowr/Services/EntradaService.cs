using GranaFacil.Data;
using GranaFacil.Data.Dtos.Entrada;
using GranaFacil.Models;
using GranaFacil.Repositories;

namespace GranaFacil.Services
{
    public class EntradaService
    {
        private readonly IEntradaRepository _repository;

        public EntradaService(IEntradaRepository repository)
        {
            _repository = repository;
        }

        public Entrada Criar(CreateEntradaDto entradaDto, int UsuarioId)
        {
            if (entradaDto.DataEntrada < DateTime.Today.AddYears(-1) || entradaDto.DataEntrada > DateTime.Today.AddYears(5))
            {
                throw new ArgumentException("Data de entrada inválida.");
            }

            if (entradaDto.Valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            if (entradaDto.Categoria == Enums.Entrada.CategoriasEntradas.ValorNaoDefinido)
            {
                throw new ArgumentException("Categoria de entrada é obrigatória.");
            }

            var entrada = new Entrada
            {
                UsuarioId = UsuarioId,
                Categoria = entradaDto.Categoria,
                Valor = entradaDto.Valor,
                DataEntrada = entradaDto.DataEntrada,
  
            };

            _repository.Criar(entrada);
            _repository.Salvar();
            return entrada;
        }

        public List<ReadEntradaDto> ListarPorUsuarioEMes (int UsuarioId, int mes, int ano)
        {

            if (mes < 01 || mes > 12)
                throw new ArgumentException("Mês inválido.");

            if (ano < 2000 || ano > DateTime.Today.Year + 5)
                throw new ArgumentException("Ano inválido.");

            var entrada = _repository.ListarPorUsuarioEMes(UsuarioId, mes, ano);

            return entrada.Select(e => new ReadEntradaDto
                {
                    Id = e.Id,
                    Categoria = e.Categoria,
                    Valor = e.Valor,
                    DataEntrada = e.DataEntrada,
                }).ToList();
        }

        public void Alterar (int idEntrada, int UsuarioId, UpdateEntradaDto entradaDto)
        {
            var entrada = _repository.BuscarPorId(idEntrada, UsuarioId);

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

            if (entradaDto.Categoria == Enums.Entrada.CategoriasEntradas.ValorNaoDefinido)
            {
                throw new ArgumentException("Categoria de entrada é obrigatória.");
            }


            entrada.Categoria = entradaDto.Categoria;
            entrada.Valor = entradaDto.Valor;
            entrada.DataEntrada = entradaDto.DataEntrada;

            _repository.Salvar();
        }

        public void Deletar (int idEntrada, int UsuarioId)
        {
            var entrada = _repository.BuscarPorId(idEntrada, UsuarioId);

            if (entrada == null)
            {
                throw new ArgumentException("Entrada não encontrada.");
            }

            _repository.Remover(entrada);
            _repository.Salvar();
        }

        public Entrada? BuscarPorId(int idEntrada, int UsuarioId)
        {
            var entrada = _repository.BuscarPorId(idEntrada, UsuarioId);
            return entrada;
        }

    }
}
