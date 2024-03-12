namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarDesativarStatusUsuarioComprador;

public class IPutUsuarioCompradorDesativarStatusUseCaseInput : UsuarioIdVerificacaoInput
{
    public string senha;
    public IPutUsuarioCompradorDesativarStatusUseCaseInput(Guid usuarioId) : base(usuarioId)
    {
    }
}