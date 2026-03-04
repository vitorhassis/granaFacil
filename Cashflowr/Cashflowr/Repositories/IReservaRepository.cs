using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IReservaRepository
    {
        void Criar(Reserva reserva);
        Reserva? BuscarPorId(int idReserva, int idUsuario);
        List<Reserva> ListarPorUsuarioEMes(int idUsuario, int mes, int ano);
        void Remover(Reserva reserva);
        void Salvar();
    }
}
