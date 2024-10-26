using MinimalsAPIs_Projeto.Dominio.DTOs;
using MinimalsAPIs_Projeto.Dominio.Entidades;

namespace MinimalsAPIs_Projeto.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}