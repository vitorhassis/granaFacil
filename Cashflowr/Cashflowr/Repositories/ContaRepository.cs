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
        
        public Conta? BuscarPorId(int idConta, int idUsuario)
        {
            return _context.Contas
            .FirstOrDefault(c => c.Id == idConta && c.IdUsuario == idUsuario);
        }

        public List<Conta> ListarPorUsuarioEMes(int idUsuario, int mes, int ano)
        {
            return _context.Contas
            .Where(c => c.IdUsuario == idUsuario &&
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
