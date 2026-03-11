using GranaFacil.Data;
using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly GranaFacilContext _context;

        public GastoRepository (GranaFacilContext context)
        {
            _context = context;
        }
        public Gasto? BuscarPorId(int idGasto, int UsuarioId)
        {
            return _context.Gastos.FirstOrDefault(c => c.Id == idGasto && c.UsuarioId == UsuarioId);
        }

        public void Criar(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
        }

        public List<Gasto> ListarPorUsuarioEMes(int idGasto, int mes, int ano)
        {
            return 
                _context.Gastos.Where(g => g.Id == idGasto &&
                g.DataCriacao.Month == mes &&
                g.DataCriacao.Year == ano)
            .ToList();
        }

        public void Remover(Gasto gasto)
        {
            _context.Gastos.Remove(gasto);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
