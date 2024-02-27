using VinilProjeto.Repository.AdminRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetAdminPerfil;

public abstract class IGetAdminPerfilUseCase : IUseCase<IGetAdminPerfilUseCaseInput, IGetAdminPerfilUseCaseOutput>
{
    protected IAdminRepository _adminRepository;

    public IGetAdminPerfilUseCase(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
}