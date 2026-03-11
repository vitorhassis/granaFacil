using System.ComponentModel.DataAnnotations;

namespace GranaFacil.Data.Dtos.Conta
{
    public class UpdateContaDto
    {
        [Required(ErrorMessage = "Nome da conta é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Valor da conta é obrigatório.")]
        [Range(0.01, 1_000_000, ErrorMessage = "Valor deve ser maior que zero.")]
        public decimal Valor { get; set; }
        [Range(0.01, 1_000_000, ErrorMessage = "Valor deve ser maior que zero.")]
        public decimal? ValorPlanejado { get; set; }

        [Required(ErrorMessage = "Data da conta é obrigatória.")]
        public DateTime DataVencimento { get; set; }

        
    }
}
