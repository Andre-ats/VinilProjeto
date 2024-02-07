using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.AdminUseCase.CadastrarAdmin;

public class ICadastrarAdminUseCaseInput : IUseCaseInput
{
    public string email;
    public string senha;
}