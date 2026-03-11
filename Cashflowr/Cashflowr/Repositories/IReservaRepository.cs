using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IReservaRepository
    {
        void Criar(Reserva reserva);
        Reserva? BuscarPorId(int idReserva, int UsuarioId);
        List<Reserva> ListarPorUsuarioEMes(int UsuarioId, int mes, int ano);
        void Remover(Reserva reserva);
        void Salvar();
    }
}
