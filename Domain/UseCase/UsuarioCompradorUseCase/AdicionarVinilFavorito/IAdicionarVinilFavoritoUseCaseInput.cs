using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.AdicionarVinilFavorito;

public class IAdicionarVinilFavoritoUseCaseInput : UsuarioIdVerificacaoInput
{
    public Guid vinilId;
    public IAdicionarVinilFavoritoUseCaseInput(Guid usuarioId) : base(usuarioId)
    {
    }
}