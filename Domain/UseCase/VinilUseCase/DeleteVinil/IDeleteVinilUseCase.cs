using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;
using VinilProjeto.UseCase.VinilUseCase.DeleteImagem;

namespace VinilProjeto.UseCase.VinilUseCase.DeleteVinil;

public abstract class IDeleteVinilUseCase : IUseCase<IDeleteVinilUseCaseInput, IDeleteVinilUseCaseOutput>
{
    protected IVinilRespository _vinilRespository;

    public IDeleteVinilUseCase(IVinilRespository vinilRespository)
    {
        _vinilRespository = vinilRespository;
    }
}