using Microsoft.EntityFrameworkCore;

namespace MinimalsAPIs_Projeto.Infraestrutura.Database
{
    public class DbContexto : DbContext
    {
        public DbSet<Administrador> Administradores { get; set;} = default!;
    }

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}