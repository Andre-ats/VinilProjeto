using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;

public abstract class IPostImagemVinilUseCase : IUseCase<IPostImagemVinilUseCaseInput, IPostImagemVinilUseCaseOutput>
{
    protected IVinilRespository _vinilRespository;

    public IPostImagemVinilUseCase(IVinilRespository _vinilRespository)
    {
        this._vinilRespository = _vinilRespository;
    }
}