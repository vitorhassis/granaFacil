using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IMetaRepository
    {
        void Criar(Meta meta);
        Meta? BuscarPorId(int idMeta, int UsuarioId);
        List<Meta> ListarPorUsuarioEMes(int UsuarioId, int mes, int ano);
        void Remover(Meta Meta);
        void Salvar();
    }
}
