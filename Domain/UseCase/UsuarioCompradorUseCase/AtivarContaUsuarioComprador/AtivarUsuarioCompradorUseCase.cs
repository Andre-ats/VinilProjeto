using VinilProjeto.Entity.Usuario;
using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.AtivarContaUsuarioComprador;

public class AtivarUsuarioCompradorUseCase : IAtivarUsuarioCompradorUseCase
{
    public AtivarUsuarioCompradorUseCase(IUsuarioCompradorRepository repository) : base(repository)
    {
    }

    protected override IAtivarUsuarioCompradorUseCaseOutput executeService(IAtivarUsuarioCompradorUseCaseInput _useCaseInput)
    {

        try
        {
            var usuarioComprador = _compradorRepository.GetUsuarioCompradorByEmail(_useCaseInput.email);
            usuarioComprador.AtivarUsuario();
            _compradorRepository.PutUsuarioComprador(usuarioComprador);

            return new IAtivarUsuarioCompradorUseCaseOutput()
            {
                resposta = $"{_useCaseInput.email} foi ativo!"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}