using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.DeleteVinisFavoritosUsuarioComprador;

public abstract class IDeleteVinisFavoritosUsuarioCompradorUseCase : IUseCase<IDeleteVinisFavoritosUsuarioCompradorUseCaseInput, IDeleteVinisFavoritosUsuarioCompradorUseCaseOutput>
{
    public IUsuarioCompradorRepository _usuarioCompradorRepository;

    public IDeleteVinisFavoritosUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository)
    {
        _usuarioCompradorRepository = usuarioCompradorRepository;
    }
}