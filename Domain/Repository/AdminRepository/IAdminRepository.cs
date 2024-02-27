using VinilProjeto.Entity.Usuario;

namespace VinilProjeto.Repository.AdminRepository;

public interface IAdminRepository
{
    public bool createAdmin(Admin admin);
    public List<Admin> getTodosAdmin();
    public Admin getAdminByEmail(string email);
    public Admin getAdminByID(Guid id);
}