using GranaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace GranaFacil.Data
{
    public class GranaFacilContext : DbContext
    {
        public GranaFacilContext(DbContextOptions<GranaFacilContext> opts) : base(opts)
        {

        }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
    }
}

