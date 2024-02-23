using VinilProjeto.Entity.Usuario;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.AdminUseCase.GetAdmin;

public class IGetAdminUseCaseOutput : IUseCaseOutput
{
    public List<Admin> getTodosAdmin = new List<Admin>();
}