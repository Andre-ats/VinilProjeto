using VinilProjeto.Entity.VinilVenda;

namespace VinilProjeto.Repository.VinilRepository;

public class EFCoreVinilRepository : IVinilRespository
{

    private DataBaseContext _dataBaseContext;

    public EFCoreVinilRepository(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    
    public bool createVinil(Vinil vinil)
    {
        _dataBaseContext.VinilDB.Add(vinil);
        return _dataBaseContext.SaveChanges() > 0;
    }
}