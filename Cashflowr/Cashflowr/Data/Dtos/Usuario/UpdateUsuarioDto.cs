using System.ComponentModel.DataAnnotations;

namespace Cashflowr.Data.Dtos.Usuario
{
    public class UpdateUsuarioDto
    {
        [Required(ErrorMessage = "Nome do usuário é obrigatório.")]
        public string Nome { get; set; } = null!; // "garanto que isso nao será null". Tira o warning do compilador

        [Required(ErrorMessage = "Email do usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")] //verifica se o formato de email é valido
        public string Email { get; set; } = null!;
    }
}
