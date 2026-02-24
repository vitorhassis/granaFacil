using GranaFacil.Enums;
using GranaFacil.Enums.Gastos;

namespace GranaFacil.Data.Dtos.Gasto
{
    public class ReadGastoDto
    {
        public int Id { get; set; }
        public Categorias Categoria { get; set; }
        public decimal Valor { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public DateTime DataReferencia { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool? IsEssencial { get; set; }
    }
}
