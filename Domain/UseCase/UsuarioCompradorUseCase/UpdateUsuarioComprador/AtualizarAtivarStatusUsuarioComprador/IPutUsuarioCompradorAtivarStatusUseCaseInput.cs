using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarStatusUsuarioComprador;

public class IPutUsuarioCompradorAtivarStatusUseCaseInput : IUseCaseInput
{
    public string email;
    public string senha;
}