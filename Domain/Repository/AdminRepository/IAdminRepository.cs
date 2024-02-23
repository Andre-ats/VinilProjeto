using VinilProjeto.Entity.Usuario;

namespace VinilProjeto.Repository.AdminRepository;

public interface IAdminRepository
{
    public bool createAdmin(Admin admin);
    public List<Admin> getTodosAdmin();
}