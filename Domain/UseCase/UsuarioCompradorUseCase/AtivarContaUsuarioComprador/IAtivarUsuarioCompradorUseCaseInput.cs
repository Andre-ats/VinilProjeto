using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.AtivarContaUsuarioComprador;

public class IAtivarUsuarioCompradorUseCaseInput : IUseCaseInput
{
    public string email;
    public string codigo;
}