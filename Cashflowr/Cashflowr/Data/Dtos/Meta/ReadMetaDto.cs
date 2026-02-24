namespace GranaFacil.Data.Dtos.Meta
{
    public class ReadMetaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public decimal ValorAcumulado { get; set; }
        public decimal ValorAlvo { get; set; }
        public decimal ValorRestante { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataPrazo { get; set;  }

    }
}
