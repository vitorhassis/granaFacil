using GranaFacil.Enums.Reserva;
namespace GranaFacil.Models;
public class Reserva
{
	public int Id { get; set; }
	public int IdUsuario { get; set; }
	public string Nome { get; set; } = null!;
    public decimal Valor { get; set; }
    public Tipos Tipo { get; set; }
	public DateTime DataCriacao { get; set; }
	
}
