using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetPerfilUsuarioComprador;

public abstract class IGetPerfilUsuarioCompradorUseCase : IUseCase<IGetPerfilUsuarioCompradorUseCaseInput, IGetPerfilUsuarioCompradorUseCaseOutput>
{
    protected IUsuarioCompradorRepository _usuarioCompradorRepository;

    public IGetPerfilUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository)
    {
        this._usuarioCompradorRepository = usuarioCompradorRepository;
    }
}