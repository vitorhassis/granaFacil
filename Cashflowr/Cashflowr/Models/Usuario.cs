using System.ComponentModel.DataAnnotations;
namespace GranaFacil.Models;
public class Usuario
{
	public int Id {  get; set; }
	public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public DateTime DataCriacao { get; set; }
    public bool IsAtivo { get; set; }
    public ICollection<Conta> Contas { get; set; } = new List<Conta>();
    public ICollection<Entrada> Entradas { get; set; } = new List<Entrada>();
    public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
    public ICollection<Meta> Metas { get; set; } = new List<Meta>();
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

}
