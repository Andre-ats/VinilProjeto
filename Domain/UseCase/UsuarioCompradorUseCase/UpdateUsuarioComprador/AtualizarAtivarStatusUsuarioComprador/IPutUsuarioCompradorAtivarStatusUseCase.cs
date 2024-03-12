using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarStatusUsuarioComprador;

public abstract class IPutUsuarioCompradorAtivarStatusUseCase : IUseCase<IPutUsuarioCompradorAtivarStatusUseCaseInput, IPutUsuarioCompradorAtivarStatusUseCaseOutput>
{
    protected IUsuarioCompradorRepository _usuarioCompradorRepository;

    public IPutUsuarioCompradorAtivarStatusUseCase(IUsuarioCompradorRepository _usuarioCompradorRepository)
    {
        this._usuarioCompradorRepository = _usuarioCompradorRepository;
    }
}