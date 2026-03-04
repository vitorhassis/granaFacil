using GranaFacil.Data;
using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly GranaFacilContext _context;

        public ReservaRepository (GranaFacilContext context)
        {
            _context = context;
        }

        public Reserva? BuscarPorId(int idReserva, int idUsuario)
        {
            return _context.Reservas
           .FirstOrDefault(r => r.Id == idReserva && r.IdUsuario == idUsuario);
        }

        public void Criar(Reserva reserva)
        {
            _context.Add(reserva);
        }

        public List<Reserva> ListarPorUsuarioEMes(int idUsuario, int mes, int ano)
        {
            return _context.Reservas
            .Where(r => r.IdUsuario == idUsuario &&
                        r.DataCriacao.Month == mes &&
                        r.DataCriacao.Year == ano)
            .ToList();
        }

        public void Remover(Reserva reserva)
        {
            _context.Remove(reserva);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
