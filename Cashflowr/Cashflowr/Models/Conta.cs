namespace GranaFacil.Models;

public class Conta
{
	public int Id { get; set; }
	public int IdUsuario { get; set; }
	public string Nome { get; set; } = null!;
	public decimal Valor { get; set; }
    public decimal? ValorPlanejado { get; set; }
    public DateTime? DataPagamento { get; set; } //? significa que o campo pode ter uma data ou pode ser null. Isso porque, nem toda conta foi paga ainda.
	public DateTime DataVencimento { get; set; }
    public bool IsPago { get; set; } = false; //comeca como falso

}
