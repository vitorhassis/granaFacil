using GranaFacil.Models;
using GranaFacil.Data.Dtos.Entrada;
using GranaFacil.Data;
using GranaFacil.Data.Dtos.Meta;
using GranaFacil.Repositories;

namespace GranaFacil.Services
{
    public class MetaService
    {
        private readonly IMetaRepository _repository;

        public MetaService(IMetaRepository repository)
        {
            _repository = repository;
        }

        public Meta Criar(CreateMetaDto metaDto, int idUsuario)
        {
            if (metaDto.DataPrazo < DateTime.Today.Date)
            {
                throw new ArgumentException("Data de prazo inválida.");
            }

            if (metaDto.ValorAcumulado < 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            if (metaDto.ValorAlvo <= 0)
            {
                throw new ArgumentException("Valor da meta deve ser maior que zero.");
            }

            if(metaDto.ValorAcumulado > metaDto.ValorAlvo)
            {
                throw new ArgumentException("Insira um valor válido.");
            }

            var meta = new Meta
            {
                IdUsuario = idUsuario,
                Nome = metaDto.Nome,
                ValorAcumulado = metaDto.ValorAcumulado,
                ValorAlvo = metaDto.ValorAlvo,
                DataPrazo = metaDto.DataPrazo,
                DataCriacao = DateTime.Today,

            };

            _repository.Criar(meta);
            _repository.Salvar();
            return meta;

        }

        public List<ReadMetaDto> ListarMetaPorUsuario(int idUsuario, int mes, int ano)
        {

            if (mes < 1 || mes > 12)
                throw new ArgumentException("Mês inválido.");

            if (ano < 2000 || ano > DateTime.Today.Year + 5)
                throw new ArgumentException("Ano inválido.");

            var meta = _repository.ListarPorUsuarioEMes(idUsuario, mes, ano);

            return meta
                .Select(m => new ReadMetaDto
                {
                    Id = m.Id,
                    Nome = m.Nome,
                    ValorAcumulado = m.ValorAcumulado,
                    ValorRestante = m.ValorAlvo - m.ValorAcumulado,
                    ValorAlvo = m.ValorAlvo,
                    DataCriacao = m.DataCriacao,
                    DataPrazo = m.DataPrazo
                }).ToList();
        }

        public void Alterar (int idMeta, int idUsuario, UpdateMetaDto metaDto)
        {
            var meta = _repository.BuscarPorId(idMeta, idUsuario);

            if (meta == null)
            {
                throw new ArgumentException("Meta não encontrada.");
            }

            if (metaDto.DataPrazo < meta.DataCriacao)
            {
                throw new ArgumentException("Data de prazo não pode ser anterior à data de criação.");
            }

            if (metaDto.ValorAcumulado < 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            if (metaDto.ValorAlvo <= 0)
            {
                throw new ArgumentException("Valor da meta deve ser maior que zero.");
            }

            if (metaDto.ValorAcumulado > metaDto.ValorAlvo)
            {
                throw new ArgumentException("Insira um valor válido.");
            }

            meta.Nome = metaDto.Nome;
            meta.ValorAcumulado = metaDto.ValorAcumulado;
            meta.ValorAlvo = metaDto.ValorAlvo;
            meta.DataPrazo = metaDto.DataPrazo;

            _repository.Salvar();
        }

        public void Deletar(int idMeta, int idUsuario)
        {
            var meta = _repository.BuscarPorId(idMeta, idUsuario);

            if (meta == null)
            {
                throw new ArgumentException("Meta não encontrada.");
            }

            _repository.Remover(meta);
            _repository.Salvar();
        }

        public Meta BuscarPorId(int idMeta, int idUsuario)
        {
            var meta = _repository.BuscarPorId(idMeta, idUsuario);
            return meta;
        }
    }
}
