using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public interface IMetaRepository
    {
        void Criar(Meta meta);
        Meta? BuscarPorId(int idMeta, int idUsuario);
        List<Meta> ListarPorUsuarioEMes(int idUsuario, int mes, int ano);
        void Remover(Meta Meta);
        void Salvar();
    }
}
