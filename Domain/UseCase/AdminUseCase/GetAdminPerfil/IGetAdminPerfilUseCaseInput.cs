using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetAdminPerfil;

public class IGetAdminPerfilUseCaseInput : UsuarioIdVerificacaoInput
{
    public IGetAdminPerfilUseCaseInput(Guid usuarioId) : base(usuarioId)
    {
    }
}