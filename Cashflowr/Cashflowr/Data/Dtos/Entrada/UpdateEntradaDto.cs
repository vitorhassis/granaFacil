using GranaFacil.Enums.Entrada;
using System.ComponentModel.DataAnnotations;

namespace GranaFacil.Data.Dtos.Entrada
{
    public class UpdateEntradaDto
    {
        [Required(ErrorMessage = "Nome da entrada é obrigatório.")]
        public CategoriasEntradas Categoria { get; set; }
        [Required(ErrorMessage = "Valor da entrada é obrigatório.")]
        [Range(0.01, 1_000_000, ErrorMessage = "Valor deve ser maior que zero.")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Data é obrigatória.")]
        public DateTime DataEntrada { get; set; }
    }
}
