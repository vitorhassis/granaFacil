using GranaFacil.Data;
using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public class MetaRepository : IMetaRepository
    {
        private readonly GranaFacilContext _context;
        public MetaRepository (GranaFacilContext context)
        {
            _context = context;
        }
        public Meta? BuscarPorId(int idMeta, int idUsuario)
        {
            return _context.Metas
           .FirstOrDefault(m => m.Id == idMeta && m.IdUsuario == idUsuario);
        }

        public void Criar(Meta meta)
        {
            _context.Add(meta);
        }

        public List<Meta> ListarPorUsuarioEMes(int idUsuario, int mes, int ano)
        {
            return _context.Metas
            .Where(m => m.IdUsuario == idUsuario &&
                        m.DataCriacao.Month == mes &&
                        m.DataCriacao.Year == ano)
            .ToList();
        }

        public void Remover(Meta meta)
        {
            _context.Remove(meta);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
