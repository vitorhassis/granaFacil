namespace GranaFacil.Data.Dtos.Conta
{
    public class ReadContasDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal? ValorPlanejado { get; set; }
        public DateTime? DataPagamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool IsPago { get; set; }
    }
}
