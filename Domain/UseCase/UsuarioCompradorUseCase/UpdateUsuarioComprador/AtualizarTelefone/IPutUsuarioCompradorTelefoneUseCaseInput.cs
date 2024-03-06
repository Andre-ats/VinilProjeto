using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarTelefone;

public class IPutUsuarioCompradorTelefoneUseCaseInput : UsuarioIdVerificacaoInput
{
    public string ddd;
    public string numero;
    public string codigo;
    public IPutUsuarioCompradorTelefoneUseCaseInput(Guid usuarioId) : base(usuarioId)
    {
    }
}