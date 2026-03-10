using GranaFacil.Data.Dtos.Usuario;
using System.Linq;
using GranaFacil.Models;
using GranaFacil.Repositories;


namespace GranaFacil.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario Criar (RegisterUsuarioDto userDto)
        {
            var userExistente = _repository.BuscarPorEmail(userDto.Email);

            if(userExistente!=null)
            {
                throw new ArgumentException("Usuario com esse email já criado!");
            }

            var user = new Usuario
            {
                Email = userDto.Email,
                Nome = userDto.Nome,
                Senha = userDto.Senha,
                DataCriacao = DateTime.UtcNow
            };

            _repository.Criar(user);
            _repository.Salvar();
            return user;
        }
        public ReadUsuarioDto BuscarPorEmail(string email)
        {
            var user = _repository.BuscarPorEmail(email);

            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            return new ReadUsuarioDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email
            };
        }

        public Usuario? BuscarPorId(int idUsuario)
        {
            return _repository.BuscarPorId(idUsuario);
        }
    }
}
