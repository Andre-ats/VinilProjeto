using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.AtivarContaUsuarioComprador;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.AdicionarVinilFavorito;

public abstract class IAdicionarVinilFavoritoUseCase : IUseCase<IAdicionarVinilFavoritoUseCaseInput, IAdicionarVinilFavoritoUseCaseOutput>
{
    protected IUsuarioCompradorRepository _compradorRepository;

    public IAdicionarVinilFavoritoUseCase(IUsuarioCompradorRepository usuarioCompradorRepository)
    {
        _compradorRepository = usuarioCompradorRepository;
    }
}