using GranaFacil.Enums.Entrada;
using System.ComponentModel.DataAnnotations;
namespace GranaFacil.Models;
public class Entrada
{
    [Key]
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public Nomes Nome { get; set; }
	public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
}
