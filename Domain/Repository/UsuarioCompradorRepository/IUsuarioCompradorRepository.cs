using VinilProjeto.Entity.Usuario;
using VinilProjeto.ValueObject.Telefone;

namespace VinilProjeto.Repository.UsuarioCompradorRepository;

public interface IUsuarioCompradorRepository
{
    public bool createUsuario(UsuarioComprador usuarioComprador);
    public List<UsuarioComprador> getUsuarioComprador();
    public UsuarioComprador GetUsuarioCompradorByEmail(string email);
    public void PutUsuarioCompradorTelefone(UsuarioComprador usuarioComprador);
    public UsuarioComprador GetUsuarioCompradorById(Guid id);
    public void PutUsuarioComprador(UsuarioComprador usuarioComprador);
}