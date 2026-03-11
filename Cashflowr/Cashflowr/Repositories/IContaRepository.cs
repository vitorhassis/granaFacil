using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IContaRepository
    {
        void Adicionar(Conta conta);

        Conta? BuscarPorId(int idConta, int UsuarioId);

        List<Conta> ListarPorUsuarioEMes(int UsuarioId, int mes, int ano);

        void Remover(Conta conta);

        void Salvar();
    }
}
