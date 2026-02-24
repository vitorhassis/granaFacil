using System.ComponentModel.DataAnnotations;

namespace GranaFacil.Data.Dtos.Meta
{
    public class UpdateMetaDto
    {
        [Required(ErrorMessage = "Nome da meta é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Valor acumulado é obrigatório.")]
        [Range(0, 1_000_000, ErrorMessage = "Valor deve ser maior que zero.")]
        public decimal ValorAcumulado { get; set; }

        [Required(ErrorMessage = "Valor da meta é obrigatório.")]
        [Range(0.01, 1_000_000, ErrorMessage = "Valor deve ser maior que zero.")]
        public decimal ValorAlvo { get; set; }

        [Required(ErrorMessage = "Data de prazo é obrigatória.")]
        public DateTime DataPrazo { get; set; }

    }
}
