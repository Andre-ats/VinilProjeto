using VinilProjeto.Repository.AdminRepository;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.GetAdminPerfil;

public class GetAdminPerfilUseCase : IGetAdminPerfilUseCase
{
    public GetAdminPerfilUseCase(IAdminRepository adminRepository) : base(adminRepository)
    {
    }

    protected override IGetAdminPerfilUseCaseOutput executeService(IGetAdminPerfilUseCaseInput _useCaseInput)
    {
        try
        {
            var output = _adminRepository.getAdminByID(_useCaseInput.getUsuarioId()) ?? throw new Exception("Id nao encontrado");

            return new IGetAdminPerfilUseCaseOutput()
            {
                email = output.email,
                id = output.id
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}