using VinilProjeto.Entity.Usuario;

namespace VinilProjeto.Repository.UsuarioCompradorRepository;

public interface IUsuarioCompradorRepository
{
    public bool createUsuario(UsuarioComprador usuarioComprador);
    public List<UsuarioComprador> getUsuarioComprador();
    public UsuarioComprador GetUsuarioCompradorByEmail(string email);
}