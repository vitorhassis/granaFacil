using GranaFacil.Enums.Gastos;
using System.ComponentModel.DataAnnotations;

namespace GranaFacil.Data.Dtos.Gasto
{
    public class CreateGastoDto
    {

        [Required(ErrorMessage = "Categoria da despesa é obrigatória.")]
        public Categorias Categoria { get; set; }

        [Required(ErrorMessage = "Forma de pagamento da despesa é obrigatória.")]
        public FormaDePagamento FormaDePagamento { get; set; }

        [Required(ErrorMessage = "Valor da despesa é obrigatório.")]
        [Range(0.01, 1_000_000, ErrorMessage = "Valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Data da despesa é obrigatória.")]
        public DateTime DataReferencia { get; set; }
        [Required]
        public bool IsEssencial { get; set; }
    }
}
