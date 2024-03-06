using VinilProjeto.Entity.Usuario;

namespace WebAPIs.Service.LoginServiceUsuarioComprador;

public interface ILoginServiceUsuarioComprador
{
    public UsuarioComprador login(string email, string senha);
}