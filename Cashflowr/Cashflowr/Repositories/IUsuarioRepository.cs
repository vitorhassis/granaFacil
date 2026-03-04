using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IUsuarioRepository
    {
        void Criar(Usuario user);
        Usuario? BuscarPorId(int idUsuario);
        Usuario? BuscarPorEmail(string email);
        void Salvar();
    }
}
