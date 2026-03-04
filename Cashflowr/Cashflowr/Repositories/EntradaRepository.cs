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

        public Entrada? BuscarPorId(int idEntrada, int idUsuario)
        {
            return _context.Entradas
            .FirstOrDefault(e => e.Id == idEntrada && e.IdUsuario == idUsuario);
        }

        public void Criar(Entrada entrada)
        {
            _context.Entradas.Add(entrada);
        }

        public List<Entrada> ListarPorUsuarioEMes(int idUsuario, int mes, int ano)
        {
            return _context.Entradas
            .Where(e => e.IdUsuario == idUsuario &&
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
