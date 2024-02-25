using VinilProjeto.Entity.Usuario;
using VinilProjeto.Repository.AdminRepository;

namespace WebAPIs.Service.LoginServiceAdmin;

public class LoginService : ILoginServiceAdmin
{
    private readonly IAdminRepository _adminRepository;

    public LoginService(IAdminRepository _adminRepository)
    {
        this._adminRepository = _adminRepository;
    }

    public Admin login(string email, string senha)
    {
        Admin admin = _adminRepository.getAdminByEmail(email);
        if (admin != null && senha.Equals(admin.senha))
        {
            return admin;
        }

        return null;

    }
}