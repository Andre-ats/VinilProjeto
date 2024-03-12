using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarDesativarStatusUsuarioComprador;

public abstract class IPutUsuarioCompradorDesativarStatusUseCase : IUseCase<IPutUsuarioCompradorDesativarStatusUseCaseInput, IPutUsuarioCompradorDesativarStatusUseCaseOutput>
{
    protected IUsuarioCompradorRepository _usuarioCompradorRepository;

    public IPutUsuarioCompradorDesativarStatusUseCase(IUsuarioCompradorRepository _usuarioCompradorRepository)
    {
        this._usuarioCompradorRepository = _usuarioCompradorRepository;
    }
}