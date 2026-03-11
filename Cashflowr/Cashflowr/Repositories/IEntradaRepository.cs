using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IEntradaRepository
    {
         void Criar(Entrada entrada);
        Entrada? BuscarPorId(int idEntrada, int UsuarioId);
        List<Entrada> ListarPorUsuarioEMes(int UsuarioId, int mes, int ano);
        void Remover(Entrada entrada);
        void Salvar();

    }
}
