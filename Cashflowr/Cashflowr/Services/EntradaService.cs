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

            _repository.Criar(entrada);
        }

        public List<ReadEntradaDto> ListarPorUsuarioEMes (int idUsuario, int mes, int ano)
        {

            if (mes < 1 || mes > 12)
                throw new ArgumentException("Mês inválido.");

            if (ano < 2000 || ano > DateTime.Today.Year + 5)
                throw new ArgumentException("Ano inválido.");

            var entrada = _repository.ListarPorUsuarioEMes(idUsuario, mes, ano);

            return entrada.Select(e => new ReadEntradaDto
                {
                    Id = e.Id,
                    Nome = e.Nome,
                    Valor = e.Valor,
                    DataEntrada = e.DataEntrada,
                }).ToList();
        }

        public void Alterar(int idEntrada, int idUsuario, UpdateEntradaDto entradaDto)
        {
            var entrada = _repository.BuscarPorId(idEntrada, idUsuario);

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

            _repository.Salvar();
        }

        public void Deletar(int idEntrada, int idUsuario)
        {
            var entrada = _repository.BuscarPorId(idEntrada, idUsuario);

            if (entrada == null)
            {
                throw new ArgumentException("Entrada não encontrada.");
            }

            _repository.Remover(entrada);
            _repository.Salvar();
        }

    }
}
