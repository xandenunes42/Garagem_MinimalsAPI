using Microsoft.EntityFrameworkCore;
using MinimalsAPIs_Projeto.Dominio.Entidades;

namespace MinimalsAPIs_Projeto.Infraestrutura.Database
{
    public class DbContexto : DbContext
    {
        
        private readonly IConfiguration _configuracaoAppSettings;
        public DbContexto(IConfiguration configuracaoAppSettings)
        {
            _configuracaoAppSettings = configuracaoAppSettings;
        }

        public DbSet<Administrador> Administradores { get; set;} = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData
            (
                new Administrador
                {
                    Id = 1,
                    Email = "administrador@email.com",
                    Senha = "root",
                    Perfil = "Adm"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql");

                if (!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
                }
                else
                {
                    throw new InvalidOperationException("String de conexão não está configurada.");
                }
            }
        }


    }
}