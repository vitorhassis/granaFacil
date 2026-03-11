using System.ComponentModel.DataAnnotations;

namespace GranaFacil.Data.Dtos.Conta
{
    public class CreateContaDto
    {
        [Required(ErrorMessage = "Nome da conta é obrigatório.")]
        [MinLength(3, ErrorMessage = "Nome deve ter pelo menos 3 caracteres.")]
        public string Nome { get; set; } = null!;

        [Range(0.01, 1_000_000, ErrorMessage = "Valor deve ser maior que zero.")]
        public decimal? Valor { get; set; }

        [Range(0.01, 1_000_000, ErrorMessage = "Valor deve ser maior que zero.")]
        public decimal? ValorPlanejado { get; set; }

        [Required(ErrorMessage = "Data do vencimento da conta é obrigatória. Use o formato YYYY-MM-DD")]
        public DateTime DataVencimento { get; set; }

    }
}
