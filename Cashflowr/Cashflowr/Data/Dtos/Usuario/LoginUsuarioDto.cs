using System.ComponentModel.DataAnnotations;

namespace GranaFacil.Data.Dtos.Usuario
{
    public class LoginUsuarioDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
