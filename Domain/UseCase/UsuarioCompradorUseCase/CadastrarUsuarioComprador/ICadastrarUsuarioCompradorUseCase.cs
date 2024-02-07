using VinilProjeto.Repository.AdminRepository;
using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.AdminUseCase.CadastrarAdmin;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;

public abstract class ICadastrarUsuarioCompradorUseCase : IUseCase<ICadastrarUsuarioCompradorUseCaseInput, ICadastrarUsuarioCompradorUseCaseOutput>
{
    protected IUsuarioCompradorRepository _usuarioCompradorRepository;

    public ICadastrarUsuarioCompradorUseCase(IUsuarioCompradorRepository usuarioCompradorRepository)
    {
        _usuarioCompradorRepository = usuarioCompradorRepository;
    }
}