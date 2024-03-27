using VinilProjeto.Entity.VinilVenda;

namespace VinilProjeto.Repository.VinilRepository;

public interface IVinilRespository
{
    public bool createVinil(Vinil vinil);
    public List<Vinil> getTodosVinil();
    public Vinil getVinilByID(Guid vinilId);
    public void postImagemVinil(VinilImagem vinilImagem);
    public void updateVinil(Vinil vinil);
    public VinilImagem getImagemByID(Guid imagemId);
}