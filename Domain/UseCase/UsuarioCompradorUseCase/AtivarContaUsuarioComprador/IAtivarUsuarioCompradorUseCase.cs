using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.AtivarContaUsuarioComprador;

public abstract class IAtivarUsuarioCompradorUseCase : IUseCase<IAtivarUsuarioCompradorUseCaseInput, IAtivarUsuarioCompradorUseCaseOutput>
{
    protected IUsuarioCompradorRepository _compradorRepository;

    public IAtivarUsuarioCompradorUseCase(IUsuarioCompradorRepository repository)
    {
        _compradorRepository = repository;
    }
}