using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarDesativarStatusUsuarioComprador;

public class PutUsuarioCompradorDesativarStatusUseCase : IPutUsuarioCompradorDesativarStatusUseCase
{
    public PutUsuarioCompradorDesativarStatusUseCase(IUsuarioCompradorRepository _usuarioCompradorRepository) : base(_usuarioCompradorRepository)
    {
    }

    protected override IPutUsuarioCompradorDesativarStatusUseCaseOutput executeService(IPutUsuarioCompradorDesativarStatusUseCaseInput _useCaseInput)
    {
        var user = _usuarioCompradorRepository.GetUsuarioCompradorById(_useCaseInput.getUsuarioId())
                   ?? throw new Exception("Usuario nao encontrado");

        try
        {
            if (_useCaseInput.senha.Equals(user.senha))
            {
                user.DesativarUsuario();
                _usuarioCompradorRepository.PutUsuarioCompradorStatus(user);
            }
            else
            {
                throw new Exception("Senha errada!");
            }

            return new IPutUsuarioCompradorDesativarStatusUseCaseOutput()
            {
                mensagem = "Usuario foi desativado!"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}