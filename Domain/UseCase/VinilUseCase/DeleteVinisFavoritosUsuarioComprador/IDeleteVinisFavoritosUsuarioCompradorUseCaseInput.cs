using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.DeleteVinisFavoritosUsuarioComprador;

public class IDeleteVinisFavoritosUsuarioCompradorUseCaseInput : UsuarioIdVerificacaoInput
{
    public Guid VinilDeleteID;

    public IDeleteVinisFavoritosUsuarioCompradorUseCaseInput(Guid usuarioId) : base(usuarioId)
    {
    }
}