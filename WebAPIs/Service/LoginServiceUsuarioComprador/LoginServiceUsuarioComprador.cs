using VinilProjeto.Entity.Usuario;
using VinilProjeto.Repository.UsuarioCompradorRepository;

namespace WebAPIs.Service.LoginServiceUsuarioComprador;

public class LoginServiceUsuarioComprador : ILoginServiceUsuarioComprador
{

    private readonly IUsuarioCompradorRepository _usuarioCompradorRepository;

    public LoginServiceUsuarioComprador(IUsuarioCompradorRepository usuarioCompradorRepository)
    {
        _usuarioCompradorRepository = usuarioCompradorRepository;
    }
    
    public UsuarioComprador login(string email, string senha)
    {
        UsuarioComprador usuarioComprador = _usuarioCompradorRepository.GetUsuarioCompradorByEmail(email);
        if(usuarioComprador.senha.Equals(senha))
        {
            return usuarioComprador;
        }

        return null;
    }
}