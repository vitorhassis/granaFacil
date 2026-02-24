using GranaFacil.Enums.Reserva;
using System.ComponentModel.DataAnnotations;

namespace GranaFacil.Data.Dtos.Reserva
{
    public class CreateReservaDto
    {
        [Required(ErrorMessage = "Nome da reserva é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Tipo da reserva é obrigatório.")]
        public Tipos Tipo { get; set; }

        [Required(ErrorMessage = "Valor da reserva é obrigatório.")]
        [Range(0.01, 1_000_000, ErrorMessage = "Valor deve ser maior que zero.")]
        public decimal Valor { get; set; }
    }
}
