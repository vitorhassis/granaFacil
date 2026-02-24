namespace GranaFacil.Models;
public class Meta
{
	public int Id { get; set; }
	public int IdUsuario { get; set; }
	public string Nome { get; set; } = null!;
	public decimal ValorAlvo { get; set; }
    public decimal ValorAcumulado { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataPrazo { get; set; }
    
	
}
