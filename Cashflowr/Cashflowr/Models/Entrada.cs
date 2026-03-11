using GranaFacil.Enums.Entrada;
namespace GranaFacil.Models;
public class Entrada
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public CategoriasEntradas Categoria { get; set; }
	public decimal Valor { get; set; }
    public DateTime DataEntrada { get; set; }
}
