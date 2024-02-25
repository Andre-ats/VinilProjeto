using VinilProjeto.Entity.Usuario;
using VinilProjeto.Repository.AdminRepository;

namespace VinilProjeto.UseCase.AdminUseCase.GetAdmin;

public class GetAdminUseCase : IGetAdminUseCase
{
    public GetAdminUseCase(IAdminRepository adminRepository) : base(adminRepository)
    {
    }

    protected override IGetAdminUseCaseOutput executeService(IGetAdminUseCaseInput _useCaseInput)
    {
        try
        {
            var output = new List<Admin>();

            output = _adminRepository.getTodosAdmin()
                     ?? throw new Exception("Erro ao encontrar Admins");

            return new IGetAdminUseCaseOutput()
            {
                getTodosAdmin = output
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}