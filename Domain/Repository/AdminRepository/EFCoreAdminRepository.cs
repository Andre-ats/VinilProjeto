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
}