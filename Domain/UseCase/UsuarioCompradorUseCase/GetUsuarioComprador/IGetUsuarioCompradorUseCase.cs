using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetUsuarioComprador;

public abstract class IGetUsuarioCompradorUseCase : IUseCase<IGetUsuarioCompradorUseCaseInput, IGetUsuarioCompradorUseCaseOutput>
{
    protected IUsuarioCompradorRepository _usuarioCompradorRepository;

    public IGetUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository)
    {
        _usuarioCompradorRepository = usuarioCompradorRepository;
    }
}