using GranaFacil.Data;
using GranaFacil.Models;

namespace GranaFacil.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GranaFacilContext _context;

        public UsuarioRepository (GranaFacilContext context)
        {
            _context = context;
        }
        public Usuario? BuscarPorEmail(string email)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Email == email);
        }

        public Usuario? BuscarPorId(int idUsuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
        }

        public void Criar(Usuario user)

        {
            _context.Add(user);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
