using GranaFacil.Enums.Gastos;

namespace GranaFacil.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Categorias Categoria { get; set; } 
        public FormaDePagamento FormaDePagamento { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; } 
        public DateTime DataReferencia { get; set; }
        public bool IsEssencial { get; set; }
    }
}
