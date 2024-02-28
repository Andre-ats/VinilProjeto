using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.GetTodosVinil;

public abstract class IGetTodosVinilUseCase : IUseCase<IGetTodosVinilUseCaseInput, IGetTodosVinilUseCaseOutput>
{
    protected IVinilRespository _vinilRespository;

    public IGetTodosVinilUseCase(IVinilRespository _vinilRespository)
    {
        this._vinilRespository = _vinilRespository;
    }
}