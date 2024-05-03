using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.GetVinilImagem;

public abstract class IGetImagemVinilUseCase : IUseCase<IGetImagemVinilUseCaseInput, IGetImagemVinilUseCaseOutput>
{
    protected IVinilRespository _vinilRespository;

    public IGetImagemVinilUseCase(IVinilRespository _vinilRespository)
    {
        this._vinilRespository = _vinilRespository;
    }
}