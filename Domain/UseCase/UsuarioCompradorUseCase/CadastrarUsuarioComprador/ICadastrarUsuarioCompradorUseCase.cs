using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;

public abstract class ICadastrarUsuarioCompradorUseCase : IUseCase<ICadastrarUsuarioCompradorUseCaseInput, ICadastrarUsuarioCompradorUseCaseOutput>
{
    protected IUsuarioCompradorRepository _compradorRepository;

    public ICadastrarUsuarioCompradorUseCase(IUsuarioCompradorRepository repository)
    {
        _compradorRepository = repository;
    }
}