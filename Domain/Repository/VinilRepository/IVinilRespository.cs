using VinilProjeto.Entity.VinilVenda;

namespace VinilProjeto.Repository.VinilRepository;

public interface IVinilRespository
{
    public bool createVinil(Vinil vinil);
    public List<Vinil> getTodosVinil();
}