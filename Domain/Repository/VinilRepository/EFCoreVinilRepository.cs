using Microsoft.EntityFrameworkCore;
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

    public List<Vinil> getTodosVinil()
    {
        return _dataBaseContext.VinilDB.ToList();
    }

    public Vinil getVinilByID(Guid vinilId)
    {
        return _dataBaseContext.VinilDB.SingleOrDefault(x => x.id.Equals(vinilId)) ?? null;
    }
    

    public void updateVinil(Vinil vinil)
    {
        _dataBaseContext.VinilDB.Update(vinil);
        _dataBaseContext.SaveChanges();
    }
    

    public void deleteVinilCascade(Vinil vinil)
    {
        
        _dataBaseContext.VinilDB.Remove(vinil);
        _dataBaseContext.SaveChanges();
    }
    
}