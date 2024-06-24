using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.MandarEmailPergunta;

public class IMandarEmailPerguntaUseCaseInput : UsuarioIdVerificacaoInput
{
    public string conteudo;
    
    public IMandarEmailPerguntaUseCaseInput(Guid usuarioId) : base(usuarioId)
    {
    }
}