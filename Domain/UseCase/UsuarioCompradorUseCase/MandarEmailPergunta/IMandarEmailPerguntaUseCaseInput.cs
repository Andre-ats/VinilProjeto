using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.MandarEmailPergunta;

public class IMandarEmailPerguntaUseCaseInput : IUseCaseInput
{
    public string email;
    public string conteudo;
}