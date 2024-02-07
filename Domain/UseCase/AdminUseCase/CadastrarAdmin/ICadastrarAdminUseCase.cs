using VinilProjeto.Repository.AdminRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.AdminUseCase.CadastrarAdmin;

public abstract class ICadastrarAdminUseCase : IUseCase<ICadastrarAdminUseCaseInput, ICadastrarAdminUseCaseOutput>
{
    protected IAdminRepository _adminRepository;

    public ICadastrarAdminUseCase(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
}