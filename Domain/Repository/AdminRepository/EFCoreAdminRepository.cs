using Microsoft.EntityFrameworkCore;
using VinilProjeto.Entity.Usuario;

namespace VinilProjeto.Repository.AdminRepository;

public class EFCoreAdminRepository : IAdminRepository
{

    private DataBaseContext _dataBaseContext;

    public EFCoreAdminRepository(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    
    public bool createAdmin(Admin admin)
    {
        _dataBaseContext.adminDB.Add(admin);
        return _dataBaseContext.SaveChanges() > 0;
    }

    public List<Admin> getTodosAdmin()
    {
        return _dataBaseContext.adminDB.ToList();
    }

    public Admin getAdminByEmail(string email)
    {
        return _dataBaseContext.adminDB.SingleOrDefault(x => x.email.Equals(email));
    }
    public Admin getAdminByID(Guid id)
    {
        return _dataBaseContext.adminDB.SingleOrDefault(x => x.id.Equals(id)) ?? null;   
    }
}