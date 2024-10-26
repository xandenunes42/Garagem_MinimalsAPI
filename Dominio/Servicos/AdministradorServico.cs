using MinimalsAPIs_Projeto.Dominio.DTOs;
using MinimalsAPIs_Projeto.Dominio.Entidades;
using MinimalsAPIs_Projeto.Dominio.Interfaces;
using MinimalsAPIs_Projeto.Infraestrutura.Database;

namespace MinimalsAPIs_Projeto.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public  AdministradorServico(DbContexto db)
        {
            _contexto = db;
        }
        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(x => x.Email == loginDTO.Email && x.Senha == loginDTO.Senha).FirstOrDefault();

            return adm;
        }
    }
}