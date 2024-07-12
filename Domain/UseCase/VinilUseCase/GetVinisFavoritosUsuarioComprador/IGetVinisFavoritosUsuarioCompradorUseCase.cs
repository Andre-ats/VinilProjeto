using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.GetVinisFavoritosUsuarioComprador;

public abstract class IGetVinisFavoritosUsuarioCompradorUseCase : IUseCase<IGetVinisFavoritosUsuarioCompradorUseCaseInput, IGetVinisFavoritosUsuarioCompradorUseCaseOutput>
{
    protected IUsuarioCompradorRepository _usuarioCompradorRepository;
    protected IVinilRespository _vinilRespository;
    
    public IGetVinisFavoritosUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository, IVinilRespository vinilRespository)
    {
        this._usuarioCompradorRepository = usuarioCompradorRepository;
        this._vinilRespository = vinilRespository;
    }
}