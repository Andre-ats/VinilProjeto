namespace VinilProjeto.UseCase.VinilUseCase.GetVinisFavoritosUsuarioComprador;

public class IGetVinisFavoritosUsuarioCompradorUseCaseInput : UsuarioIdVerificacaoInput
{
    public IGetVinisFavoritosUsuarioCompradorUseCaseInput(Guid usuarioId) : base(usuarioId)
    {
    }
}