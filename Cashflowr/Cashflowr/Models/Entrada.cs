using GranaFacil.Enums.Entrada;
namespace GranaFacil.Models;
public class Entrada
{
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public Nomes Nome { get; set; }
	public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
}
