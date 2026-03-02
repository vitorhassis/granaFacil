using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IContaRepository
    {
        void Adicionar(Conta conta);

        Conta? BuscarPorId(int idConta, int idUsuario);

        List<Conta> ListarPorUsuarioEMes(int idUsuario, int mes, int ano);

        void Remover(Conta conta);

        void Salvar();
    }
}
