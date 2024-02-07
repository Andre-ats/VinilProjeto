using VinilProjeto.Entity.Usuario;

namespace VinilProjeto.Repository.UsuarioCompradorRepository;

public class EFCoreUsuarioCompradorRepository : IUsuarioCompradorRepository
{

    private DataBaseContext _dataBaseContext;

    public EFCoreUsuarioCompradorRepository(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    
    public bool createUsuario(UsuarioComprador usuarioComprador)
    {
        _dataBaseContext.UsuarioCompradorDB.Add(usuarioComprador);
        return _dataBaseContext.SaveChanges() > 0;
    }
}