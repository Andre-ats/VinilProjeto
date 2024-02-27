using VinilProjeto.Entity.Usuario;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetAdminPerfil;

public class IGetAdminPerfilUseCaseOutput : IUseCaseOutput
{
    public string email;
    public Guid id;
}