using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IGastoRepository
    {
        void Criar(Gasto gasto);
        Gasto? BuscarPorId(int idGasto, int idUsuario);
        List<Gasto> ListarPorUsuarioEMes(int idUsuario, int mes, int ano);
        void Remover(Gasto gasto);
        void Salvar();
    }
}
