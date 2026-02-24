using System.ComponentModel.DataAnnotations;
namespace GranaFacil.Models;
public class Usuario
{
	[Key]
	public int Id {  get; set; }
	public String Nome { get; set; } = null!;
    public String Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public DateTime DataCriacao { get; set; }
    public bool IsAtivo { get; set; }
}
