using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarStatusUsuarioComprador;

public class PutUsuarioCompradorAtivarStatusUseCase : IPutUsuarioCompradorAtivarStatusUseCase
{
    public PutUsuarioCompradorAtivarStatusUseCase(IUsuarioCompradorRepository _usuarioCompradorRepository) : base(_usuarioCompradorRepository)
    {
    }

    protected override IPutUsuarioCompradorAtivarStatusUseCaseOutput executeService(IPutUsuarioCompradorAtivarStatusUseCaseInput useCaseUseCaseInput)
    {
        try
        {
            var user = _usuarioCompradorRepository.GetUsuarioCompradorByEmail(useCaseUseCaseInput.email) 
                       ?? throw new Exception("Erro ao encontrar o usuario");

            if (user.senha.Equals(useCaseUseCaseInput.senha))
            {
                user.AtivarUsuario();
                _usuarioCompradorRepository.PutUsuarioCompradorAtivarStatus(user);
            }
            else
            {
                throw new Exception("Usuario nao ativado!");
            }

            return new IPutUsuarioCompradorAtivarStatusUseCaseOutput()
            {
                mensagem = "Usuario Ativo!"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}