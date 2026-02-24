using GranaFacil.Enums.Entrada;

namespace GranaFacil.Data.Dtos.Entrada
{
    public class ReadEntradaDto
    {
        public int Id { get; set; }
        public Nomes Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataEntrada { get; set; }
    }
}
