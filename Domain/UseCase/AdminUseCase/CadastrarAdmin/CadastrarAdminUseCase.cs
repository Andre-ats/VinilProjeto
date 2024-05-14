using VinilProjeto.Entity.Usuario;
using VinilProjeto.Factory.Entity.Usuario;
using VinilProjeto.Helpers.Hash;
using VinilProjeto.Repository.AdminRepository;

namespace VinilProjeto.UseCase.AdminUseCase.CadastrarAdmin;

public class CadastrarAdminUseCase : ICadastrarAdminUseCase
{
    public CadastrarAdminUseCase(IAdminRepository adminRepository) : base(adminRepository)
    {
    }

    protected override ICadastrarAdminUseCaseOutput executeService(ICadastrarAdminUseCaseInput _useCaseInput)
    {
        try
        {
            
            var hash = Hash256.stringHash256(_useCaseInput.senha);
            
            Admin admin = new AdminFactory()
                .setEmail(_useCaseInput.email)
                .setSenha(hash)
                .build();

            _ = _adminRepository.createAdmin(admin) ? true : throw new Exception("Erro de criacao de Admin");

            return new ICadastrarAdminUseCaseOutput()
            {
                result = $"Admin {admin.email} criado!"
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}