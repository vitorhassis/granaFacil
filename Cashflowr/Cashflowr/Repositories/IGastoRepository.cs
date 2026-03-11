using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IGastoRepository
    {
        void Criar(Gasto gasto);
        Gasto? BuscarPorId(int idGasto, int UsuarioId);
        List<Gasto> ListarPorUsuarioEMes(int UsuarioId, int mes, int ano);
        void Remover(Gasto gasto);
        void Salvar();
    }
}
