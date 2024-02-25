using VinilProjeto.Repository.AdminRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.AdminUseCase.GetAdmin;

public abstract class IGetAdminUseCase : IUseCase<IGetAdminUseCaseInput, IGetAdminUseCaseOutput>
{
    protected IAdminRepository _adminRepository;

    public IGetAdminUseCase(IAdminRepository adminRepository)
    {
        this._adminRepository = adminRepository;
    }
}