using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.MandarEmailPergunta;

public abstract class IMandarEmailPerguntaUseCase : IUseCase<IMandarEmailPerguntaUseCaseInput, IMandarEmailPerguntaUseCaseOutput>
{
    protected IUsuarioCompradorRepository _compradorRepository;

    public IMandarEmailPerguntaUseCase(IUsuarioCompradorRepository repository)
    {
        _compradorRepository = repository;
    }
}