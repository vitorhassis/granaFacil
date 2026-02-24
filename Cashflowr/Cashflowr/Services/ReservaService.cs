using GranaFacil.Models;
using GranaFacil.Data.Dtos.Meta;
using GranaFacil.Data;
using GranaFacil.Data.Dtos.Reserva;
using GranaFacil.Enums.Reserva;

namespace GranaFacil.Services
{
    public class ReservaService
    {
        private readonly GranaFacilContext _context;

        public ReservaService(GranaFacilContext context)
        {
            _context = context;
        }

        public void Criar (CreateReservaDto reservaDto, int idUsuario)
        {
            if(string.IsNullOrWhiteSpace(reservaDto.Nome)) {
                throw new ArgumentException("Nome da reserva não pode ser vazio.");
            }

            if(reservaDto.Tipo == Tipos.ValorNaoDefinido)
            {
                throw new ArgumentException("Insira um tipo de reserva válido.");
            }

            if (reservaDto.Valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            var reserva = new Reserva
            {
                IdUsuario = idUsuario,
                Nome = reservaDto.Nome,
                Valor = reservaDto.Valor,
                DataCriacao = DateTime.Today,
                
            };

            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        public List<ReadReservaDto> ListarReservaPorUsuario(int idUsuario, int mes, int ano)
        {

            if (mes < 1 || mes > 12)
                throw new ArgumentException("Mês inválido.");

            if (ano < 2000 || ano > DateTime.Today.Year + 5)
                throw new ArgumentException("Ano inválido.");

            return _context.Reservas
                .Where(r => r.IdUsuario == idUsuario && r.DataCriacao.Month == mes && r.DataCriacao.Year == ano)
                .Select(r => new ReadReservaDto
                {
                    Id = r.Id,
                    Nome = r.Nome,
                    Tipo = r.Tipo,
                    Valor = r.Valor,
                    DataCriacao = r.DataCriacao,
                }).ToList();
        }

        public void Alterar (UpdateReservaDto reservaDto, int idUsuario, int idReserva)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.Id == idReserva && r.IdUsuario == idUsuario);

            if (reserva == null)
            {
                throw new Exception("Reserva não encontrada.");
            }


            if (string.IsNullOrWhiteSpace(reservaDto.Nome))
            {
                throw new ArgumentException("Nome da reserva não pode ser vazio.");
            }

            if (reservaDto.Tipo == Tipos.ValorNaoDefinido)
            {
                throw new ArgumentException("Insira um tipo de reserva válido.");
            }

            if (reservaDto.Valor <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero.");
            }

            reserva.IdUsuario = idUsuario;
            reserva.Nome = reservaDto.Nome;
            reserva.Valor = reservaDto.Valor;
            reserva.DataCriacao = DateTime.Today;
            
            _context.SaveChanges();
        }

        public void Deletar(int idUsuario, int idReserva)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.Id == idReserva && r.IdUsuario == idUsuario);

            if (reserva == null)
            {
                throw new ArgumentException("Reserva não encontrada.");
            }

            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
        }

    }
}
