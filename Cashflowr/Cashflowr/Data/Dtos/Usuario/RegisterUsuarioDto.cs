using System.ComponentModel.DataAnnotations;

namespace GranaFacil.Data.Dtos.Usuario
{
    public class RegisterUsuarioDto
    {
        [Required(ErrorMessage = "Nome do usuário é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Email do usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")] //verifica se o formato de email é valido
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Senha do usuário é obrigatória.")]
        [MinLength(6, ErrorMessage = "Senha deve ter pelo menos 6 caracteres.")]
        public string Senha { get; set; } = null!;
    }
}
