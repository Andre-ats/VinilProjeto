using VinilProjeto.Helpers.Email;
using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.MandarEmailPergunta;

public class MandarEmailPerguntaUseCase : IMandarEmailPerguntaUseCase
{
    public MandarEmailPerguntaUseCase(IUsuarioCompradorRepository repository) : base(repository)
    {
    }
    protected override IMandarEmailPerguntaUseCaseOutput executeService(IMandarEmailPerguntaUseCaseInput _useCaseInput)
    {
        try
        {
            var emailUsuario = _compradorRepository.GetUsuarioCompradorById(_useCaseInput.getUsuarioId());
            new EmailEnviarMensagem().EnviarDuvida(_useCaseInput.conteudo, emailUsuario.email);
            return new IMandarEmailPerguntaUseCaseOutput()
            {
                resposta = "Enviado com sucesso!"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine("O Email nao foi possivel enviar");
            throw;
        }
    }
    
}