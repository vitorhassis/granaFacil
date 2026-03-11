using GranaFacil.Data;
using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly GranaFacilContext _context;

        public EntradaRepository(GranaFacilContext context)
        {
            _context = context;
        }

        public Entrada? BuscarPorId(int idEntrada, int UsuarioId)
        {
            return _context.Entradas
            .FirstOrDefault(e => e.Id == idEntrada && e.UsuarioId == UsuarioId);
        }

        public void Criar(Entrada entrada)
        {
            _context.Entradas.Add(entrada);
        }

        public List<Entrada> ListarPorUsuarioEMes(int UsuarioId, int mes, int ano)
        {
            return _context.Entradas
            .Where(e => e.UsuarioId == UsuarioId &&
                        e.DataEntrada.Month == mes &&
                        e.DataEntrada.Year == ano)
            .ToList();
        }

        public void Remover(Entrada entrada)
        {
            _context.Remove(entrada);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
