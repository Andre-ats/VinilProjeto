using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.DeleteImagem;

public abstract class IDeleteImagemVinilUseCase : IUseCase<IDeleteImagemUseCaseInput, IDeleteImagemUseCaseOutput>
{
    protected IVinilRespository _vinilRespository;

    public IDeleteImagemVinilUseCase(IVinilRespository vinilRespository)
    {
        _vinilRespository = vinilRespository;
    }
}