using VinilProjeto.Entity.Usuario;

namespace WebAPIs.Service.LoginServiceAdmin;

public interface ILoginServiceAdmin
{
    public Admin login(string email, string senha);
}