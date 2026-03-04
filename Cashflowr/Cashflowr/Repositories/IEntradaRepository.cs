using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IEntradaRepository
    {
         void Criar(Entrada entrada);
        Entrada? BuscarPorId(int idEntrada, int idUsuario);
        List<Entrada> ListarPorUsuarioEMes(int idUsuario, int mes, int ano);
        void Remover(Entrada entrada);
        void Salvar();

    }
}
