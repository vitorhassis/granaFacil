using GranaFacil.Enums.Reserva;

namespace GranaFacil.Data.Dtos.Reserva
{
    public class ReadReservaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public Tipos Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
