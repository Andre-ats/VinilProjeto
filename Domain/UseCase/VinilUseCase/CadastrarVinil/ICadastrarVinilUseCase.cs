using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;

public abstract class ICadastrarVinilUseCase : IUseCase<ICadastrarVinilUseCaseInput, ICadastrarVinilUseCaseOutput>
{
    protected IVinilRespository _vinilRespository;

    public ICadastrarVinilUseCase(IVinilRespository vinilRespository)
    {
        _vinilRespository = vinilRespository;
    }
}