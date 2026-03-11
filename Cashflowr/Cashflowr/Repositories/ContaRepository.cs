using GranaFacil.Data;
using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly GranaFacilContext _context;

        //DI
        public ContaRepository (GranaFacilContext context)
        {
            _context = context;
        }
        public void Adicionar(Conta conta)
        {
            _context.Contas.Add(conta);
        }
        
        public Conta? BuscarPorId(int idConta, int UsuarioId)
        {
            return _context.Contas
            .FirstOrDefault(c => c.Id == idConta && c.UsuarioId == UsuarioId);
        }

        public List<Conta> ListarPorUsuarioEMes(int UsuarioId, int mes, int ano)
        {
            return _context.Contas
            .Where(c => c.UsuarioId == UsuarioId &&
                        c.DataVencimento.Month == mes &&
                        c.DataVencimento.Year == ano)
            .ToList();
        }

        public void Remover(Conta conta)
        {
            _context.Contas.Remove(conta);
            
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
