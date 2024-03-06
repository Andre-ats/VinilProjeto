using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarTelefone;

public abstract class IPutUsuarioCompradorTelefoneUseCase : IUseCase<IPutUsuarioCompradorTelefoneUseCaseInput, IPutUsuarioCompradorTelefoneUseCaseOutput>
{
    protected IUsuarioCompradorRepository _usuarioCompradorRepository;

    public IPutUsuarioCompradorTelefoneUseCase(IUsuarioCompradorRepository _usuarioCompradorRepository)
    {
        this._usuarioCompradorRepository = _usuarioCompradorRepository;
    }
}