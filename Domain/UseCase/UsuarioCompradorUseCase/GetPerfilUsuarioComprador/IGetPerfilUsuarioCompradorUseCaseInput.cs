using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetPerfilUsuarioComprador;

public class IGetPerfilUsuarioCompradorUseCaseInput : UsuarioIdVerificacaoInput
{
    public IGetPerfilUsuarioCompradorUseCaseInput(Guid usuarioId) : base(usuarioId)
    {
    }
}